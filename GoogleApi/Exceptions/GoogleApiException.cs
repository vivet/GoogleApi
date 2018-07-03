using System;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Exceptions
{
    /// <summary>
    /// Exception that is thrown when Google returns a status code 
    /// </summary>
    public class GoogleApiException : Exception
    {
        /// <summary>
        /// The request.
        /// </summary>
        public virtual IRequest Request { get; set; }

        /// <summary>
        /// The response if any is returned and deserialized.
        /// </summary>
        public virtual IResponse Response { get; set; }

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
        /// <param name="innerException">The inner exception.</param>
        public GoogleApiException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}