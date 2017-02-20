using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Image associated with this promotion, if there is one.
    /// </summary>
    [DataContract]
    public class PromotionImage
    {
        /// <summary>
        /// URL of the image for this promotion link.
        /// </summary>
        [DataMember(Name = "source")]
        public virtual string Source { get; set; }

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
    }
}