using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geolocation.Response
{
    /// <summary>
    /// Error response.
    /// In the case of an error, a standard format error response body will be returned and the HTTP status code will be set to an error status.
    /// The response contains an object with a single error object with the following keys:
    /// </summary>
    [DataContract]
    public class ErrorResponse : BaseResponse
    {
        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [JsonProperty("code")]
        public virtual string Code { get; set; }

        /// <summary>
        /// A short description of the error.
        /// </summary>
        [JsonProperty("message")]
        public virtual string Message { get; set; }

        /// <summary>
        /// A list of errors which occurred. 
        /// Each error contains an identifier for the type of error (the reason) and a short description (the message).
        /// </summary>
        [JsonProperty("errors")]
        public virtual IEnumerable<Error> Errors { get; set; }
    }
}