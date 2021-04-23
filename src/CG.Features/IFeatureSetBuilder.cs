// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Sources;
using System;
using System.Collections.Generic;

namespace CG.Features
{
    /// <summary>
    /// This interface represents an object that builds <see cref="IFeatureSet"/>
    /// objects.
    /// </summary>
    public interface IFeatureSetBuilder
    {
        /// <summary>
        /// Gets a key/value collection that can be used to share data between the <see cref="IFeatureSetBuilder"/>
        /// and the registered <see cref="IFeatureSetSource"/>s.
        /// </summary>
        IDictionary<string, object> Properties { get; }

        /// <summary>
        /// This property returns the sources used to obtain feature set values.
        /// </summary>
        IList<IFeatureSetSource> Sources { get; }

        /// <summary>
        /// This method adds a new feature set source.
        /// </summary>
        /// <param name="source">The feature set source to add.</param>
        /// <returns>The same <see cref="IFeatureSetBuilder"/>.</returns>
        IFeatureSetBuilder Add(IFeatureSetSource source);

        /// <summary>
        /// Builds an <see cref="IFeatureSet"/> object with keys and values from the set of sources registered in
        /// <see cref="Sources"/>.
        /// </summary>
        /// <returns>An <see cref="IFeatureSet"/> object with keys and values from the registered sources.</returns>
        IFeatureSet Build();
    }
}
