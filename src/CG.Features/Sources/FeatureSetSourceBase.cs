// Portions copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See Apache-LICENSE.txt in the project root for license information.

// All changes and/or additions copyright (c) CODEGATOR. All rights reserved.
// Licensed under the MIT license. See MIT-LICENSE.md in the project root for license information.

using CG.Features.Providers;
using System;

namespace CG.Features.Sources
{
    /// <summary>
    /// This class is a base implementation of the <see cref="IFeatureSetSource"/>
    /// class.
    /// </summary>
    public abstract class FeatureSetSourceBase : IFeatureSetSource
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc />
        public abstract IFeatureSetProvider Build(
            IFeatureSetBuilder builder
            );

        #endregion
    }
}
