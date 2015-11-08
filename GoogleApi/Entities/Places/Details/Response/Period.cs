using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Details.Response
{
    /// <summary>
    /// Period.
    /// </summary>
    [DataContract]
    public class Period
    {
        /// <summary>
        /// Open contains a pair of day and time objects describing when the Place opens.
        /// </summary>
        [DataMember(Name = "open")]
        public virtual DayTime Open { get; set; }
        
        /// <summary>
        /// Open contains a pair of day and time objects describing when the Place closes.
        /// </summary>
        [DataMember(Name = "close")]
        public virtual DayTime Close { get; set; }
    }
}