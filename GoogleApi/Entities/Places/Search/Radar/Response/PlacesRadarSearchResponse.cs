using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Radar.Response
{
    /// <summary>
    /// Places RadarSearch Response
    /// </summary>
    public class PlacesRadarSearchResponse : BasePlacesSearchResponse
    {
        /// <summary>
        /// Results.
        /// </summary>
        [JsonProperty("results")]
        public virtual IEnumerable<RadarResult> Results { get; set; }
    }
}