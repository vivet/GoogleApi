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

        /// <summary>
        /// Viewport contains the recommended viewport for displaying the returned result, specified as two latitude,longitude values defining 
        /// the southwest and northeast corner of the viewport bounding box. 
        /// Generally the viewport is used to frame a result when displaying it to a user.
        /// </summary>
        [JsonProperty("viewPort")]
        public virtual ViewPort ViewPort { get; set; }
    }
}