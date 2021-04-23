// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Sources;
using System;

namespace CG.Features.Providers
{
    /// <summary>
    /// This class is chained feature set provider.
    /// </summary>
    public class ChainedFeatureSetProvider : FeatureSetProviderBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a reference to an internal feature set.
        /// </summary>
        private readonly IFeatureSet _featureSet;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="ChainedFeatureSetProvider"/>
        /// class.
        /// </summary>
        /// <param name="source">The source to use for the provider.</param>
        public ChainedFeatureSetProvider(
            ChainedFeatureSetSource source
            )
        {
            // Save the references.
            _featureSet = source.FeatureSet;
        }

        #endregion
    }
}
