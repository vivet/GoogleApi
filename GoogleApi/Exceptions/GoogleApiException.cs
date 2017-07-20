using System;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Exceptions
{
    /// <summary>
    /// Exception that is thrown when Google returns a status code 
    /// </summary>
    public class GoogleApiException : Exception
    {
        /// <summary>
        /// See <see cref="GoogleApi.Entities.Common.Enums.Status"/>.
        /// </summary>
        public virtual Status Status { get; }

        /// <summary>
        /// Constructor, accepting a error message and a optional status.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="status">The <see cref="GoogleApi.Entities.Common.Enums.Status"/> (optional). Default to <see cref="GoogleApi.Entities.Common.Enums.Status.UnknownError"/></param>
        public GoogleApiException(string message, Status? status = null)
            : base(message)
        {
            this.Status = status ?? Status.UnknownError;
        }
    }
}