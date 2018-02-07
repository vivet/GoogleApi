using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
    /// <summary>
    /// Element.
    /// </summary>
    public class Element
    {
        /// <summary>
        /// Status: See Status Codes for a list of possible status codes.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Status Status { get; set; }

        /// <summary>
        /// Duration: The duration of this route, expressed in seconds (the value field) and as text. 
        /// The textual representation is localized according to the query's language parameter.
        /// </summary>
        [JsonProperty("duration")]
        public virtual Duration Duration { get; set; }

        /// <summary>
        /// The length of time it takes to travel this route, based on current and historical traffic conditions.
        /// See the traffic_model request parameter for the options you can use to request that the returned value is optimistic, pessimistic, or a best-guess estimate.
        /// The duration is expressed in seconds (the value field) and as text.The textual representation is localized according to the query's language parameter. 
        /// The duration in traffic is returned only if all of the following are true:
        /// - The request includes a departure_time parameter.
        /// - The request includes a valid API key, or a valid Google Maps APIs Premium Plan client ID and signature.
        /// - Traffic conditions are available for the requested route.
        /// - The mode parameter is set to driving.
        /// </summary>
        [JsonProperty("duration_in_traffic")]
        public virtual Duration DurationInTraffic { get; set; }

        /// <summary>
        /// Distance: The total distance of this route, expressed in meters (value) and as text. 
        /// The textual value uses the unit system specified with the unit parameter of the original request, or the origin's region.
        /// </summary>
        [JsonProperty("distance")]
        public virtual Distance Distance { get; set; }

        /// <summary>
        /// If present, contains the total fare (that is, the total ticket costs) on this route. 
        /// This property is only returned for transit requests and only for transit providers where fare information is available.
        /// </summary>
        [JsonProperty("fare")]
        public virtual Fare Fare { get; set; }
    }
}