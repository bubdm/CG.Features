// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Providers;
using System;
using System.Collections.Generic;

namespace CG.Features.Sources.Sources
{
    /// <summary>
    /// This class is an in-memory feature set source.
    /// </summary>
    public class MemoryFeatureSetSource : FeatureSetSourceBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// The initial key-value feature set pairs.
        /// </summary>
        public IEnumerable<KeyValuePair<string, bool>> InitialData { get; set; }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method builds the <see cref="MemoryFeatureSetProvider"/> for 
        /// this source.
        /// </summary>
        /// <param name="builder">The <see cref="IFeatureSetBuilder"/>.</param>
        /// <returns>A <see cref="MemoryFeatureSetProvider"/></returns>
        public override IFeatureSetProvider Build(
            IFeatureSetBuilder builder
            )
        {
            // Create the provider.
            var provider = new MemoryFeatureSetProvider(this);

            // Return the provider.
            return provider;
        }

        #endregion
    }
}
