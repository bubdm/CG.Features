﻿using System;

namespace CG.Features
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