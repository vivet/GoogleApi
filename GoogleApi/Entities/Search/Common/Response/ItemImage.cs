using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemImage
    {
        /// <summary>
        /// A URL pointing to the webpage hosting the image.
        /// </summary>
        [JsonProperty("contextLink")]
        public virtual string ContextLink { get; set; }

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

        /// <summary>
        /// The size of the image, in pixels.
        /// </summary>
        [JsonProperty("byteSize")]
        public virtual int ByteSize { get; set; }

        /// <summary>
        /// A URL to the thumbnail image.
        /// </summary>
        [JsonProperty("thumbnailLink")]
        public virtual string ThumbnailLink { get; set; }

        /// <summary>
        /// The height of the thumbnail image, in pixels.
        /// </summary>
        [JsonProperty("thumbnailHeight")]
        public virtual int ThumbnailHeight { get; set; }

        /// <summary>
        /// The width of the thumbnail image, in pixels.
        /// </summary>
        [JsonProperty("thumbnailWidth")]
        public virtual int ThumbnailWidth { get; set; }
    }
}