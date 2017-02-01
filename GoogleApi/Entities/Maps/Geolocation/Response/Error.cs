using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Geolocation.Response
{
    /// <summary>
    /// Error.
    /// In the case of an error, a standard format error response body will be returned and the HTTP status code will be set to an error status.
    /// The response contains an object with a single error object with the following keys:
    /// </summary>
    [DataContract]
    public class Error : BaseResponse
    {
        /// <summary>
        /// A list of errors which occurred. 
        /// Each error contains an identifier for the type of error (the reason) and a short description (the message).
        /// </summary>
        [DataMember(Name = "errors")]
        public virtual Errors Errors { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [DataMember(Name = "code")]
        public virtual string Code { get; set; }

        /// <summary>
        /// A short description of the error.
        /// </summary>
        [DataMember(Name = "message")]
        public virtual string Message { get; set; }
    }
}