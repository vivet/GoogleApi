using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

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
        public virtual Status Status { get; set; }

        /// <summary>
        /// When the status code is other than 'Ok', there may be an additional error_message field within the Directions response object. 
        /// This field contains more detailed information about the reasons behind the given status code.
        /// Note: This field is not guaranteed to be always present, and its content is subject to change.
        /// </summary>
        public virtual string ErrorMessage { get; set; }

        [DataMember(Name = "status")]
        internal virtual string StatusStr
        {
            get => this.Status.ToEnumString();
            set => this.Status = value.ToEnum<Status>();
        }

        [DataMember(Name = "error_message")]
        internal virtual string ErrorMsg
        {
            get => this.Status.ToString();
            set => this.Status = (Status) Enum.Parse(typeof(Status), value);
        }
    }
}