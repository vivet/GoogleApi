using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Image associated with this promotion, if there is one.
    /// </summary>
    public class PromotionImage
    {
        /// <summary>
        /// URL of the image for this promotion link.
        /// </summary>
        [JsonProperty("source")]
        public virtual string Source { get; set; }

        /// <summary>
        /// Image width in pixels.
        /// </summary>
        [JsonProperty("width")]
        public virtual int Width { get; set; }

        /// <summary>
        /// Image height in pixels.
        /// </summary>
        [JsonProperty("height")]
        public virtual int Height { get; set; }
    }
}