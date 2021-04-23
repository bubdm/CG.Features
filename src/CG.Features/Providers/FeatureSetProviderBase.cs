// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CG.Features.Providers
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

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method triggers the reload change token and creates a new one.
        /// </summary>
        protected void OnReload()
        {
            // Get the previous token.
            var previousToken = Interlocked.Exchange(
                ref _reloadToken, 
                new FeatureSetReloadToken()
                );

            // Reload the token.
            previousToken.OnReload();
        }

        #endregion
    }
}
