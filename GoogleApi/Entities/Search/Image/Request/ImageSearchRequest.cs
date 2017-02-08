using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Request;
using GoogleApi.Helpers;

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
        /// Overridden search type property, defaulting to Image. 
        /// </summary>
        public override SearchType SearchType { get; set; } = Common.Enums.SearchType.Image;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
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