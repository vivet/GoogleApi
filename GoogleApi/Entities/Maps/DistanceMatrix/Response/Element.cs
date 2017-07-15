using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
    /// <summary>
    /// Element.
    /// /// </summary>
    public class Element
    {
        /// <summary>
        /// Status: See Status Codes for a list of possible status codes.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Status Status { get; set; }

        /// <summary>
        /// Duration: The duration of this route, expressed in seconds (the value field) and as text. The textual representation is localized according to the query's language parameter.
        /// </summary>
        [JsonProperty("duration")]
        public virtual Duration Duration { get; set; }

        /// <summary>
        /// Distance: The total distance of this route, expressed in meters (value) and as text. The textual value uses the unit system specified with the unit parameter of the original request, or the origin's region.
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