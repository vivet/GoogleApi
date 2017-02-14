using System;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places requests.
    /// </summary>
    public abstract class BasePlacesRequest : SignableRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/place/";

        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => BasePlacesRequest.BASE_URL;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParameters GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("ApiKey must be provided");

            return parameters;
        }
    }
}