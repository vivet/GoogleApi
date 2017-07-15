using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Common
{
    /// <summary>
    /// Opening Hours.
    /// </summary>
    public class OpeningHours
    {
        /// <summary>
        /// OpenNow is a boolean value indicating if the place is open at the current time.
        /// </summary>
        [JsonProperty("OpenNow")]
        public virtual bool OpenNow { get; set; }
    }
}