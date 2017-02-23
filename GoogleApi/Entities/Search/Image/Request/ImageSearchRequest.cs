using System.Collections.Generic;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Web.Request;

namespace GoogleApi.Entities.Search.Image.Request
{
    /// <summary>
        /// Image Search Request.
        /// </summary>
    public class ImageSearchRequest : WebSearchRequest
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
            this.ApiSpecific.SearchType = SearchType.Image;
        }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> QueryStringParameters
        {
            get
            {
                var parameters = base.QueryStringParameters;

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
}