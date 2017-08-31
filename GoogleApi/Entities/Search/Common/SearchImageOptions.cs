using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Search Image Options.
    /// </summary>
    public class SearchImageOptions
    {
        /// <summary>
        /// Type - Returns images of a type. 
        /// </summary>
        public virtual ImageType? ImageType { get; set; }

        /// <summary>
        /// Size - Returns images of a specified size.
        /// </summary>
        public virtual ImageSize? ImageSize { get; set; }

        /// <summary>
        /// ColorType - Returns black and white, grayscale, or color images: mono, gray, and color.
        /// </summary>
        public virtual ColorType? ImageColorType { get; set; }

        /// <summary>
        /// DominantColor - Returns images of a specific dominant color. 
        /// </summary>
        public virtual DominantColorType? ImageDominantColor { get; set; }
    }
}