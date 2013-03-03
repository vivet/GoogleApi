using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class Geometry
    {
        /// <summary>
        /// location contains the geocoded latitude,longitude value for this place.
        /// </summary>
        [DataMember(Name = "location")]
        public Location Location { get; set; }
    }
}