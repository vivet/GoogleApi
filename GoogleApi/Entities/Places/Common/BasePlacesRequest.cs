using GoogleApi.Entities.Common;

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
    }
}