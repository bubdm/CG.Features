using Microsoft.Extensions.Primitives;
using System;
using System.Threading;

namespace CG.Features
{
    /// <summary>
    /// This class is a default implementation of the <see cref="IChangeToken"/>
    /// interface, for feature sets.
    /// </summary>
    public class FeatureSetReloadToken : IChangeToken
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a cancellation token source.
        /// </summary>
        private CancellationTokenSource _cts = new CancellationTokenSource();

        #endregion

        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// Thie property indicates if this token will proactively raise callbacks. 
        /// </summary>
        public bool ActiveChangeCallbacks => true;

        /// <summary>
        /// This property gets a value that indicates if a change has occurred.
        /// </summary>
        public bool HasChanged => _cts.IsCancellationRequested;

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method registers for a callback that will be invoked when the 
        /// entry has changed. <see cref="IChangeToken.HasChanged"/> MUST be set 
        /// before the callback is invoked.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <param name="state">State to be passed into the callback.</param>
        /// <returns>A callback object.</returns>
        public IDisposable RegisterChangeCallback(
            Action<object> callback, 
            object state
            ) => _cts.Token.Register(callback, state);

        /// <summary>
        /// This method is used to trigger the change token when a reload occurs.
        /// </summary>
        public void OnReload() => _cts.Cancel();

        #endregion
    }
}
