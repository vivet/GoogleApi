using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    [DataContract]
    public class Geometry
    {
        /// <summary>
        /// location contains the geocoded latitude,longitude value for this place.
        /// </summary>
        [DataMember(Name = "location")]
        public virtual Location Location { get; set; }
    }
}