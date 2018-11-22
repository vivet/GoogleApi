using System.Collections.Generic;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Search.Web.Request;

namespace GoogleApi.Entities.Search.Image.Request
{
    /// <summary>
    /// Image Search Request.
    /// </summary>
    public class ImageSearchRequest : WebSearchRequest
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
            this.SearchType = SearchType.Image;
        }

        /// <summary>
        /// See <see cref="WebSearchRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            parameters.Add("searchType", this.SearchType.ToString().ToLower());

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