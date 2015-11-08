using System;
using GoogleApi.Entities.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places requests.
    /// </summary>
    public abstract class BasePlacesRequest : BaseRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/place/";

        protected internal override string BaseUrl
        {
            get
            {
                return BasePlacesRequest.BASE_URL;
            }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("ApiKey must be provided");

            _parameters.Add("key", this.Key);

            return _parameters;
        }
    }
}