using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class Period
    {
        /// <summary>
        /// Open contains a pair of day and time objects describing when the Place opens.
        /// </summary>
        [DataMember(Name = "open")]
        public DayTime Open { get; set; }
        
        /// <summary>
        /// Open contains a pair of day and time objects describing when the Place closes.
        /// </summary>
        [DataMember(Name = "close")]
        public DayTime Close { get; set; }
    }
}