// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Providers;
using System;

namespace CG.Features.Sources
{
    /// <summary>
    /// This class is a chained feature set source.
    /// </summary>
    public class ChainedFeatureSetSource : FeatureSetProviderBase, IFeatureSetSource
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a reference to the chained feature set.
        /// </summary>
        public IFeatureSet FeatureSet { get; set; }

        /// <summary>
        /// This method builds the <see cref="ChainedFeatureSetProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IFeatureSetBuilder"/>.</param>
        /// <returns>A <see cref="ChainedFeatureSetProvider"/></returns>
        public virtual IFeatureSetProvider Build(
            IFeatureSetBuilder builder
            ) => new ChainedFeatureSetProvider(this);

        #endregion
    }
}
