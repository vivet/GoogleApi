using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Elevation.Response
{
    /// <summary>
    /// Elevation Response.
    /// </summary>
    [DataContract]
    public class ElevationResponse : BaseResponse
    {
        /// <summary>
        /// Results.
        /// </summary>
        [JsonProperty("results")]
        public virtual IEnumerable<Result> Results { get; set; }
    }
}