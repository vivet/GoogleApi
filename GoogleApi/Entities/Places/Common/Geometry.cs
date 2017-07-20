using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Geometry.
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Location contains the geocoded latitude and longitude value for this place.
        /// </summary>
        [JsonProperty("location")]
        public virtual Location Location { get; set; }
    }
}