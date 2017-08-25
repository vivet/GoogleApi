using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Image.Request
{
    /// <summary>
    /// Image Search Request.
    /// </summary>
    public class ImageSearchRequest : BaseSearchRequest
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

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ImageSearchRequest()
        {
            this.Options.SearchType = SearchType.Image;
        }

        /// <summary>
        /// See <see cref="BaseSearchRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.ImageType != null)
                parameters.Add("imgType", this.ImageType.ToString().ToLower());

            if (this.ImageSize != null)
                parameters.Add("imgSize", this.ImageSize.ToString().ToLower());

            if (this.ImageColorType != null)
                parameters.Add("imgColorType", this.ImageColorType.ToString().ToLower());

            if (this.ImageDominantColor != null)
                parameters.Add("imgDominantColor", this.ImageDominantColor.ToString().ToLower());

            return parameters;
        }
    }
}