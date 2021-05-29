// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Providers;
using CG.Features.Sources;
using CG.Validations;
using System;
using System.Collections.Generic;

namespace CG.Features
{
    /// <summary>
    /// This object is a default implementation of the <see cref="IFeatureSet"/>
    /// interface.
    /// </summary>
    public class FeatureSetBuilder : IFeatureSetBuilder
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// Gets a key/value collection that can be used to share data between the <see cref="IFeatureSetBuilder"/>
        /// and the registered <see cref="IFeatureSetSource"/>s.
        /// </summary>
        public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();

        /// <summary>
        /// This property returns the sources used to obtain feature set values.
        /// </summary>
        public IList<IFeatureSetSource> Sources { get; } = new List<IFeatureSetSource>();

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method adds a new feature set source.
        /// </summary>
        /// <param name="source">The feature set source to add.</param>
        /// <returns>The <see cref="IFeatureSetBuilder"/> reference, for 
        /// chaining calls together.</returns>
        public IFeatureSetBuilder Add(
            IFeatureSetSource source
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(source, nameof(source));

            // Add the source.
            Sources.Add(source);

            // Return the builder.
            return this;
        }

        // *******************************************************************

        /// <summary>
        /// Builds an <see cref="IFeatureSet"/> object with keys and values from the set of sources registered in
        /// <see cref="Sources"/>.
        /// </summary>
        /// <returns>An <see cref="IFeatureSet"/> object with keys and values from the registered sources.</returns>
        public IFeatureSet Build()
        {
            // Get the providers.
            var providers = new List<IFeatureSetProvider>();

            // Loop through the sources.
            foreach (var source in Sources)
            {
                // Build the provider.
                var provider = source.Build(this);

                // Add the provider to the collection.
                providers.Add(provider);
            }

            // Create the feature set.
            var featureSet = new FeatureSet(providers);

            // Return the feature set.
            return featureSet;
        }

        #endregion
    }
}
