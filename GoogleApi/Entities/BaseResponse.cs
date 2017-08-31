using System.Collections.Generic;
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
        /// See <see cref="IResponse.ErrorMessage"/>.
        /// </summary>
        [JsonProperty("error_message")]
        public virtual string ErrorMessage { get; set; }

        /// <summary>
        /// See <see cref="IResponse.HtmlAttributions"/>.
        /// </summary>
        [JsonProperty("html_attributions")]
        public virtual IEnumerable<string> HtmlAttributions { get; set; }
    }
}