using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Body line.
    /// </summary>
    public class BodyLine
    {
        /// <summary>
        /// The block object's text, if it has text.
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The block object's html text, if it has text.
        /// </summary>
        [JsonProperty("htmlTitle")]
        public virtual string HtmlTitle { get; set; }

        /// <summary>
        /// The anchor text of the block object's link, if it has a link.
        /// </summary>
        [JsonProperty("link")]
        public virtual string Link { get; set; }

        /// <summary>
        /// The URL of the block object's link, if it has one
        /// </summary>
        [JsonProperty("url")]
        public virtual string Url { get; set; }
    }
}