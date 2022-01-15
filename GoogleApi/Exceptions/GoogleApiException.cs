using GoogleApi.Entities.Common.Enums;
using System;
using System.Runtime.Serialization;

namespace GoogleApi.Exceptions
{
    /// <summary>
    /// Exception that is thrown when Google returns a status code
    /// </summary>
    [Serializable]
    public class GoogleApiException : Exception
    {
        /// <summary>
        /// Constructor, accepting a error message and a optional status.
        /// </summary>
        /// <param name="message">The error message.</param>
        public GoogleApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor, accepting a error message and a optional status.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="status">status to set</param>
        public GoogleApiException(string message, Status? status = null)
            : base(message, null)
        {
            Status = status;
        }

        /// <summary>
        /// Constructor, accepting a error message and an inner exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public GoogleApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected GoogleApiException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public Status? Status { get; set; }
    }
}