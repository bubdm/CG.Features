// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Providers;
using System;

namespace CG.Features.Sources
{
    /// <summary>
    /// This interface represents an object that is a source of feature set 
    /// key/values for an application.
    /// </summary>
    public interface IFeatureSetSource
    {
        /// <summary>
        /// This method builds the <see cref="IFeatureSetProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IFeatureSetBuilder"/>.</param>
        /// <returns>An <see cref="IFeatureSetProvider"/></returns>
        IFeatureSetProvider Build(IFeatureSetBuilder builder);
    }
}
