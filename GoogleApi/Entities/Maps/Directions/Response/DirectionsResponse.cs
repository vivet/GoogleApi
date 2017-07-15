using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response
{
    /// <summary>
    /// Directions Response.
    /// </summary>
    public class DirectionsResponse : BaseResponse
    {
        /// <summary>
        /// "routes" contains an array of routes from the origin to the destination. See Routes below.
        /// </summary>
        [JsonProperty("routes")]
        public virtual IEnumerable<Route> Routes { get; set; }

        /// <summary>
        /// "routes" contains an array of routes from the origin to the destination. See Routes below.
        /// </summary>
        [JsonProperty("geocoded_waypoints")]
        public virtual IEnumerable<Route> WayPoints { get; set; }
    }
}