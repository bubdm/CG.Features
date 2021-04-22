using Microsoft.Extensions.Primitives;
using System;

namespace CG.Features
{
    /// <summary>
    /// This interface represents an object that provides feature set key/values 
    /// for an application.
    /// </summary>
    public interface IFeatureSetProvider
    {
        /// <summary>
        /// Tries to get a feature value for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> if a value for the specified key was found, otherwise <c>false</c>.</returns>
        bool TryGet(
            string key, 
            out bool value
            );

        /// <summary>
        /// Sets a feature value for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Set(
            string key, 
            bool value
            );

        /// <summary>
        /// Returns a change token if this provider supports change tracking, null otherwise.
        /// </summary>
        /// <returns>An <see cref="IChangeToken"/>.</returns>
        IChangeToken GetReloadToken();

        /// <summary>
        /// Loads feature set values from the source represented by this <see cref="IFeatureSetProvider"/>.
        /// </summary>
        void Load();
    }
}
