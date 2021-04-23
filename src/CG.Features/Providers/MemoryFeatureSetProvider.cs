using CG.Features.Sources;
using CG.Features.Sources.Sources;
using System;
using System.Collections.Generic;

namespace CG.Features.Providers
{
    /// <summary>
    /// This class is an in-memory feature set provider.
    /// </summary>
    public class MemoryFeatureSetProvider : 
        FeatureSetProviderBase, 
        IEnumerable<KeyValuePair<string, bool>>
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a the source for the provider.
        /// </summary>
        private readonly MemoryFeatureSetSource _source;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="ChainedFeatureSetProvider"/>
        /// class.
        /// </summary>
        /// <param name="source">The source to use for the provider.</param>
        public MemoryFeatureSetProvider(
            MemoryFeatureSetSource source
            )
        {
            // Save the references.
            _source = source;

            // Is there initial data in the source?
            if (null != _source.InitialData)
            {
                // Loop through the features
                foreach (var kvp in _source.InitialData)
                {
                    // Add the feature to the collection.
                    Data.Add(kvp.Key, kvp.Value);
                }
            }
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method adds a new feature key-value pair to the provider.
        /// </summary>
        /// <param name="key">The feature set key.</param>
        /// <param name="value">The feature set value.</param>
        public void Add(
            string key, 
            bool value
            )
        {
            // Add the feature to the collection.
            Data.Add(key, value);
        }

        // *******************************************************************

        /// <summary>
        /// Ths method returns an enumerator that iterates through the features.
        /// </summary>
        /// <returns>An enumerator that iterates through the features.</returns>
        public IEnumerator<KeyValuePair<string, bool>> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        // *******************************************************************

        /// <summary>
        /// This method returns an enumerator that iterates through the features.
        /// </summary>
        /// <returns>An enumerator that iterates through the features.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
