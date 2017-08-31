using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    /// <summary>
    /// Error Detail.
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// The type of error.
        /// </summary>
        [JsonProperty("@type")]
        public virtual string Type { get; set; }

        /// <summary>
        /// Links associated with the errors.
        /// </summary>
        [JsonProperty("links")]
        public virtual IEnumerable<Link> Links { get; set; }
    }
}