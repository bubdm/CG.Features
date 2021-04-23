// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Sources;
using CG.Features.Sources.Sources;
using CG.Validations;
using System;
using System.Collections.Generic;

namespace CG.Features
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IFeatureSetBuilder"/>
    /// type.
    /// </summary>
    public static partial class FeatureSetBuilderExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method adds an existing feature set to <paramref name="featureSetBuilder"/>.
        /// </summary>
        /// <param name="featureSetBuilder">The <see cref="IFeatureSetBuilder"/> 
        /// to add to.</param>
        /// <param name="featureSet">The <see cref="IFeatureSet"/> to add.</param>
        /// <returns>The <see cref="IFeatureSetBuilder"/>.</returns>
        public static IFeatureSetBuilder AddFeatureSet(
            this IFeatureSetBuilder featureSetBuilder, 
            IFeatureSet featureSet
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(featureSetBuilder, nameof(featureSetBuilder))
                .ThrowIfNull(featureSet, nameof(featureSet));

            // Add the source to the builder.
            featureSetBuilder.Add(
                new ChainedFeatureSetSource { FeatureSet = featureSet }
                );

            // Return the builder.
            return featureSetBuilder;
        }

        // *******************************************************************

        /// <summary>
        /// Adds the memory configuration provider to <paramref name="featureSetBuilder"/>.
        /// </summary>
        /// <param name="featureSetBuilder">The <see cref="IFeatureSetBuilder"/> to add to.</param>
        /// <returns>The <see cref="IFeatureSetBuilder"/>.</returns>
        public static IFeatureSetBuilder AddInMemoryCollection(
            this IFeatureSetBuilder featureSetBuilder
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(featureSetBuilder, nameof(featureSetBuilder));

            // Add the source.
            featureSetBuilder.Add(new MemoryFeatureSetSource());

            // Return the builder.
            return featureSetBuilder;
        }

        // *******************************************************************

        /// <summary>
        /// This method adds the memory feature set provider to <paramref name="featureSetBuilder"/>.
        /// </summary>
        /// <param name="featureSetBuilder">The <see cref="IFeatureSetBuilder"/> to add to.</param>
        /// <param name="initialData">The data to add to memory configuration provider.</param>
        /// <returns>The <see cref="IFeatureSetBuilder"/>.</returns>
        public static IFeatureSetBuilder AddInMemoryCollection(
            this IFeatureSetBuilder featureSetBuilder,
            IEnumerable<KeyValuePair<string, bool>> initialData
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(featureSetBuilder, nameof(featureSetBuilder))
                .ThrowIfNull(initialData, nameof(initialData));

            // Add the source.
            featureSetBuilder.Add(
                new MemoryFeatureSetSource { InitialData = initialData }
                );

            // Return the builder.
            return featureSetBuilder;
        }

        // *******************************************************************

        /// <summary>
        /// This method adds a new configuration source.
        /// </summary>
        /// <param name="builder">The <see cref="IFeatureSetBuilder"/> to add to.</param>
        /// <param name="configureSource">Configures the source secrets.</param>
        /// <returns>The <see cref="IFeatureSetBuilder"/>.</returns>
        public static IFeatureSetBuilder Add<TSource>(this IFeatureSetBuilder builder, Action<TSource> configureSource) where TSource : IFeatureSetSource, new()
        {
            var source = new TSource();
            configureSource?.Invoke(source);
            return builder.Add(source);
        }

        #endregion
    }
}
