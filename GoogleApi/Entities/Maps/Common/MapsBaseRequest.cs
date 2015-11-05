using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class MapsBaseRequest : BaseRequest
    {
        private const string BASE_URL = "maps.google.com/maps/api/";

        protected internal override string BaseUrl
        {
            get
            {
                return MapsBaseRequest.BASE_URL;
            }
        }
    }
}
