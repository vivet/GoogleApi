using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities
{
    /// <summary>
    /// MapsBase Response.
    /// Base abstract class for Google responses.
    /// </summary>
    [DataContract]
    public abstract class BaseResponse : IResponse
    {
        /// <summary>
        /// See <see cref="IResponse.RawJson"/>
        /// </summary>
        public virtual string RawJson { get; set; }

        /// <summary>
        /// See <see cref="IResponse.RawQueryString"/>
        /// </summary>
        public virtual string RawQueryString { get; set; }

        /// <summary>
        /// Success status of the request.
        /// </summary>
        [DataMember(Name = "status")]
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public virtual Status Status { get; set; }

        /// <summary>
        /// When the status code is other than 'Ok', there may be an additional error_message field within the Directions response object. 
        /// This field contains more detailed information about the reasons behind the given status code.
        /// Note: This field is not guaranteed to be always present, and its content is subject to change.
        /// </summary>
        [DataMember(Name = "error_message")]
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public virtual string ErrorMessage { get; set; }
    }
}