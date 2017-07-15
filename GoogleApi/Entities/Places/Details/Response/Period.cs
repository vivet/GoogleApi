using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Details.Response
{
    /// <summary>
    /// Period.
    /// </summary>
    public class Period
    {
        /// <summary>
        /// Open contains a pair of day and time objects describing when the Place opens.
        /// </summary>
        [JsonProperty("open")]
        public virtual DayTime Open { get; set; }

        /// <summary>
        /// Open contains a pair of day and time objects describing when the Place closes.
        /// </summary>
        [JsonProperty("close")]
        public virtual DayTime Close { get; set; }
    }
}