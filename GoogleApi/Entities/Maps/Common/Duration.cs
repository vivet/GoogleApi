using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Duration indicates the total duration of this leg
    /// These fields may be absent if the duration is unknown.
    /// </summary>
    [DataContract(Name = "duration")]
    public class Duration
    {
        /// <summary>
        /// Value as timespan.
        /// </summary>
        public virtual TimeSpan Value { get; set; }

        /// <summary>
        /// Text contains a human-readable representation of the duration.
        /// </summary>
        [JsonProperty("text")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Contains the time zone of this station. 
        /// The value is the name of the time zone as defined in the IANA Time Zone Database, e.g. "America/New_York".
        /// </summary>
        [JsonProperty("time_zone")]
        public virtual string TimeZone { get; set; }

        // TODO: Remove, Internal
        [JsonProperty("value")]
        internal virtual int ValueInSec
        {
            get => (int)Math.Round(Value.TotalSeconds);
            set => Value = TimeSpan.FromSeconds(value);
        }
    }
}