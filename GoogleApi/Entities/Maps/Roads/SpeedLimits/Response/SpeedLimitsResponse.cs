using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Response
{
    /// <summary>
    /// SpeedLimits Response.
    /// </summary>
    public class SpeedLimitsResponse : BaseRoadsResponse
    {
        /// <summary>
        /// SpeedLimits — A collection of road metadata. 
        /// </summary>
        [JsonProperty("speedLimits")]
        public virtual IEnumerable<SpeedLimit> SpeedLimits { get; set; }
    }
}