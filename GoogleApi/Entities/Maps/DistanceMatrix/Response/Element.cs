using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common.Enums;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
    /// <summary>
    /// The information about each origin-destination pairing is returned in an element entry.
    /// /// </summary>
    [DataContract(Name = "element")]
    public class Element
    {
        /// <summary>
        /// status: See Status Codes for a list of possible status codes.
        /// </summary>
        [DataMember(Name = "elements")]
        public virtual Status Status { get; set; }

        /// <summary>
        /// duration: The duration of this route, expressed in seconds (the value field) and as text. The textual representation is localized according to the query's language parameter.
        /// </summary>
        [DataMember(Name = "duration")]
        public virtual Duration Duration { get; set; }

        /// <summary>
        /// distance: The total distance of this route, expressed in meters (value) and as text. The textual value uses the unit system specified with the unit parameter of the original request, or the origin's region.
        /// </summary>
        [DataMember(Name = "distance")]
        public virtual Distance Distance { get; set; }
    }
}