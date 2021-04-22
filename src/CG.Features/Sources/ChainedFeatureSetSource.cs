using System;

namespace CG.Features
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
