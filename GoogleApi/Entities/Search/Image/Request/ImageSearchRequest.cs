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
        /// Search Image Options.
        /// </summary>
        public virtual SearchImageOptions ImageOptions { get; set; } = new SearchImageOptions();

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

            if (this.ImageOptions.ImageType != null)
                parameters.Add("imgType", this.ImageOptions.ImageType.ToString().ToLower());

            if (this.ImageOptions.ImageSize != null)
                parameters.Add("imgSize", this.ImageOptions.ImageSize.ToString().ToLower());

            if (this.ImageOptions.ImageColorType != null)
                parameters.Add("imgColorType", this.ImageOptions.ImageColorType.ToString().ToLower());

            if (this.ImageOptions.ImageDominantColor != null)
                parameters.Add("imgDominantColor", this.ImageOptions.ImageDominantColor.ToString().ToLower());

            return parameters;
        }
    }
}