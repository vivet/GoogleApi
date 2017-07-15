using System.Collections.Generic;
using GoogleApi.Entities.Places.Search.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Radar.Response
{
    /// <summary>
    /// Places RadarSearch Response
    /// </summary>
    public class PlacesRadarSearchResponse : BasePlacesSearchResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("results")]
        public virtual IEnumerable<RadarResult> Results { get; set; }
    }
}