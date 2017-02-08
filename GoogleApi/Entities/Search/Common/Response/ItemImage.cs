using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ItemImage
    {
        /// <summary>
        /// A URL pointing to the webpage hosting the image.
        /// </summary>
        [DataMember(Name = "contextLink")]
        public virtual string ContextLink { get; set; }

        /// <summary>
        /// Image width in pixels.
        /// </summary>
        [DataMember(Name = "width")]
        public virtual int Width { get; set; }

        /// <summary>
        /// Image height in pixels.
        /// </summary>
        [DataMember(Name = "height")]
        public virtual int Height { get; set; }

        /// <summary>
        /// The size of the image, in pixels.
        /// </summary>
        [DataMember(Name = "byteSize")]
        public virtual int ByteSize { get; set; }

        /// <summary>
        /// A URL to the thumbnail image.
        /// </summary>
        [DataMember(Name = "thumbnailLink")]
        public virtual string ThumbnailLink { get; set; }

        /// <summary>
        /// The height of the thumbnail image, in pixels.
        /// </summary>
        [DataMember(Name = "thumbnailHeight")]
        public virtual int ThumbnailHeight { get; set; }

        /// <summary>
        /// The width of the thumbnail image, in pixels.
        /// </summary>
        [DataMember(Name = "thumbnailWidth")]
        public virtual int ThumbnailWidth { get; set; }
    }
}