using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    public abstract class PlacesBaseRequest : BaseRequest
    {
        protected internal override string BaseUrl
        {
            get
            {
                return "maps.googleapis.com/maps/api/place/";
            }
        }
    }
}