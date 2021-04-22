using CG.Features.Properties;
using CG.Validations;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CG.Features
{
    /// <summary>
    /// This class is a default implementation of the <see cref="IFeatureSet"/> 
    /// interface.
    /// </summary>
    public class FeatureSet : IFeatureSet
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a reload token, for the feature set.
        /// </summary>
        private FeatureSetReloadToken _changeToken = new FeatureSetReloadToken();

        /// <summary>
        /// This field contains a list of feature set providers.
        /// </summary>
        private IList<IFeatureSetProvider> _providers;

        #endregion

        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// The <see cref="IFeatureSetProvider"/>s for this feature set.
        /// </summary>
        public IEnumerable<IFeatureSetProvider> Providers => _providers;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="FeatureSet"/>
        /// class.
        /// </summary>
        /// <param name="providers">The list of providers to use with the feature set.</param>
        public FeatureSet(
            IList<IFeatureSetProvider> providers
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(providers, nameof(providers));

            // Save the reference.
            _providers = providers;

            // Loop through the providers.
            foreach (var p in providers)
            {
                // Load each provider.
                p.Load();

                // Register the change token.
                ChangeToken.OnChange(
                    () => p.GetReloadToken(), 
                    () => RaiseChanged()
                    );
            }
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This operator gets or sets the value of a feature.
        /// </summary>
        /// <param name="key">The feature key.</param>
        /// <returns>The feature value.</returns>
        public virtual bool this[string key] 
        {
            get
            {
                // Loop through the providers.
                foreach (var provider in _providers.Reverse())
                {
                    // Get the value of the feature.
                    bool value;
                    if (provider.TryGet(key, out value))
                    {
                        // Return the value of the feature.
                        return value;
                    }
                }

                // False by default.
                return false;
            }

            set
            {
                // Do we not have any providers?
                if (false == _providers.Any())
                {
                    // Panic!!
                    throw new InvalidOperationException(
                        message: Resources.Error_NoSources
                        );
                }

                // Loop through the providers.
                foreach (var provider in _providers)
                {
                    // Set the value in each provider.
                    provider.Set(key, value);
                }
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method returns a <see cref="IChangeToken"/> that can be 
        /// used to observe when this feature set is reloaded.
        /// </summary>
        /// <returns>A <see cref="IChangeToken"/>.</returns>
        public virtual IChangeToken GetReloadToken() => _changeToken;

        // *******************************************************************

        /// <summary>
        /// Force the feature set values to be reloaded from the underlying sources.
        /// </summary>
        public void Reload()
        {
            // Loop through the providers.
            foreach (var provider in _providers)
            {
                // Load  each provider.
                provider.Load();
            }

            // Tell the world we changed.
            RaiseChanged();
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is called to reload the change token.
        /// </summary>
        private void RaiseChanged()
        {
            // Get the previous token.
            var previousToken = Interlocked.Exchange(
                ref _changeToken, 
                new FeatureSetReloadToken()
                );

            // Reload the token.
            previousToken.OnReload();
        }

        #endregion
    }
}
