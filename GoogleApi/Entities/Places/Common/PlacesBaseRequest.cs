using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places requests.
    /// </summary>
    public abstract class PlacesBaseRequest : BaseRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/place/";

        protected internal override string BaseUrl
        {
            get
            {
                return PlacesBaseRequest.BASE_URL;
            }
        }
    }
}