using System;
using GoogleApi.Entities.Places.Search.Common;

namespace GoogleApi.Entities.Places.Search.Text.Request
{
    /// <summary>
    /// Places TextSearch Request.
    /// </summary>
    public class PlacesTextSearchRequest : BasePlacesSearchRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "textsearch/json";

        /// <summary>
        /// Query — The text string on which to search, for example: "restaurant". 
        /// The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesSearchRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> colletion.</returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Query))
                    throw new ArgumentException("Query is required.");

                var parameters = base.QueryStringParameters;

                parameters.Add("query", this.Query);

                return parameters;
            }
        }
    }
}