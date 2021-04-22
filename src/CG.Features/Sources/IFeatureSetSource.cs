using System;

namespace CG.Features
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
