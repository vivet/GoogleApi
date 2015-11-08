using System;
using GoogleApi.Entities.Places.Search.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Search.Text.Request
{
    /// <summary>
    /// Places TextSearch Request.
    /// </summary>
    public class PlacesTextSearchRequest : BasePlacesSearchRequest
    {
        /// <summary>
        /// Query — The text string on which to search, for example: "restaurant". 
        /// The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.
        /// </summary>
        public string Query { get; set; }

        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "textsearch/";
            }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Query))
                throw new ArgumentException("Query must not be null");

            _parameters.Add("query", this.Query);

            return _parameters;
        }
    }
}