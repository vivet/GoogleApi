using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities
{
    /// <summary>
    /// Base abstract class for responses.
    /// </summary>
    public abstract class BaseResponse : IResponse
    {
        /// <summary>
        /// See <see cref="IResponse.RawJson"/>.
        /// </summary>
        public virtual string RawJson { get; set; }

        /// <summary>
        /// See <see cref="IResponse.RawQueryString"/>.
        /// </summary>
        public virtual string RawQueryString { get; set; }

        /// <summary>
        /// See <see cref="IResponse.Status"/>.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Status? Status { get; set; }

        /// <summary>
        /// When the status code is other than 'Ok', there may be an additional error_message field within the response object. 
        /// This field contains more detailed information about the reasons behind the given status code.
        /// Note: This field is not guaranteed to be always present, and its content is subject to change.
        /// </summary>
        [JsonProperty("error_message")]
        public virtual string ErrorMessage { get; set; }
    }
}