using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Error Detail.
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// The domain assocaited with the error.
        /// </summary>
        [JsonProperty("domain")]
        public virtual string Doamin { get; set; }

        /// <summary>
        /// The error reason.
        /// </summary>
        [JsonProperty("reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// A short description of the error.
        /// </summary>
        [JsonProperty("message")]
        public virtual string ErrorMessage { get; set; }
    }
}