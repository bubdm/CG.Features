using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Features
{
    /// <summary>
    /// This interface represents an object that contains a collection of 
    /// key/value application feature properties.
    /// </summary>
    public interface IFeatureSet
    {
        /// <summary>
        /// This operator gets or sets the value of a feature.
        /// </summary>
        /// <param name="key">The feature key.</param>
        /// <returns>The feature value.</returns>
        bool this[string key] { get; set; }

        /// <summary>
        /// This method returns a <see cref="IChangeToken"/> that can be 
        /// used to observe when this feature set is reloaded.
        /// </summary>
        /// <returns>A <see cref="IChangeToken"/>.</returns>
        IChangeToken GetReloadToken();
    }
}
