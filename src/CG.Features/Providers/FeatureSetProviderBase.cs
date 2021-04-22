using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace CG.Features
{
    /// <summary>
    /// This interface represents an object that provides feature set key/values 
    /// for an application.
    /// </summary>
    public abstract class FeatureSetProviderBase : IFeatureSetProvider
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a reference to a realod token.
        /// </summary>
        private FeatureSetReloadToken _reloadToken = new FeatureSetReloadToken();

        #endregion

        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the feature set key value pairs for this provider.
        /// </summary>
        protected IDictionary<string, bool> Data { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="FeatureSetProviderBase"/>
        /// class.
        /// </summary>
        protected FeatureSetProviderBase()
        {
            Data = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc />
        public virtual bool TryGet(
            string key, 
            out bool value
            ) => Data.TryGetValue(key, out value);
        
        // *******************************************************************

        /// <inheritdoc />
        public virtual void Set(
            string key, 
            bool value
            ) => Data[key] = value;

        // *******************************************************************

        /// <inheritdoc />
        public IChangeToken GetReloadToken() => _reloadToken;

        // *******************************************************************

        /// <inheritdoc />
        public virtual void Load() { }

        #endregion
    }
}
