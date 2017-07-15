using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geolocation.Response
{
    /// <summary>
    /// Error.
    /// </summary>
    [DataContract]
    public class Error : BaseResponse
    {
        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [JsonProperty("domain")]
        public virtual string Domain { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [JsonProperty("reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [JsonProperty("message")]
        public virtual string Message { get; set; }
    }
}