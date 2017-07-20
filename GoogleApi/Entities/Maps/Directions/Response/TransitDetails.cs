using GoogleApi.Entities.Maps.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response
{
    /// <summary>
    /// Transit Details.
    /// </summary>
    public class TransitDetails
    {
        /// <summary>
        /// Contains information about the stop/station for this part of the trip
        /// </summary>
        [JsonProperty("arrival_stop")]
        public virtual Stop ArrivalStop { get; set; }

        /// <summary>
        /// Contains information about the stop/station for this part of the trip.
        /// </summary>
        [JsonProperty("departure_stop")]
        public virtual Stop DepartureStop { get; set; }

        /// <summary>
        /// Contain the arrival times for this leg of the journey
        /// </summary>
        [JsonProperty("arrival_time")]
        public virtual Duration ArrivalTime { get; set; }

        /// <summary>
        /// Contain the departure times for this leg of the journey
        /// </summary>
        [JsonProperty("departure_time")]
        public virtual Duration DepartureTime { get; set; }

        /// <summary>
        /// Specifies the direction in which to travel on this line, as it is marked on the vehicle or at the departure stop. This will often be the terminus station.
        /// </summary>
        [JsonProperty("headsign")]
        public virtual string Headsign { get; set; }

        /// <summary>
        /// Specifies the expected number of seconds between departures from the same stop at this time. For example, with a headway value of 600, you would expect a ten minute wait if you should miss your bus.
        /// </summary>
        [JsonProperty("headway")]
        public virtual int Headway { get; set; }

        /// <summary>
        /// Contains the number of stops in this step, counting the arrival stop, but not the departure stop. For example, if your directions involve leaving from Stop A, passing through stops B and C, and arriving at stop D, num_stops will return 3.
        /// </summary>
        [JsonProperty("num_stops")]
        public virtual int NumberOfStops { get; set; }

        /// <summary>
        /// Contains information about the transit line used in this step.
        /// </summary>
        [JsonProperty("line")]
        public virtual Line Lines { get; set; }
    }
}