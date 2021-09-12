using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response
{
    /// <summary>
    /// Contains information about the stop/station for this part of the trip
    /// </summary>
    public class Stop
    {
        /// <summary>
        /// The name of the transit station/stop. eg. "Union Square".
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// The location of the transit station/stop, represented as lattitude and longitude.
        /// </summary>
        [JsonProperty("location")]
        public virtual Coordinate Location { get; set; }
    }
}