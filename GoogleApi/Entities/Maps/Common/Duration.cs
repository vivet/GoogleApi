using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Duration indicates the total duration of this leg
    /// These fields may be absent if the duration is unknown.
    /// </summary>
    public class Duration
    {
        /// <summary>
        /// Text contains a human-readable representation of the duration.
        /// </summary>
        [JsonProperty("text")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Value in seconds.
        /// </summary>
        [JsonProperty("value")]
        public virtual int Value { get; set; }

        /// <summary>
        /// Contains the time zone of this station. 
        /// The value is the name of the time zone as defined in the IANA Time Zone Database, e.g. "America/New_York".
        /// </summary>
        [JsonProperty("time_zone")]
        public virtual string TimeZone { get; set; }
    }
}