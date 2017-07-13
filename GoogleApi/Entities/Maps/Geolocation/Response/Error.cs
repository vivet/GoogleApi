using System.Runtime.Serialization;

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
        [DataMember(Name = "domain")]
        public virtual string Domain { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [DataMember(Name = "reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// This is the same as the HTTP status of the response.
        /// </summary>
        [DataMember(Name = "message")]
        public virtual string Message { get; set; }
    }
}