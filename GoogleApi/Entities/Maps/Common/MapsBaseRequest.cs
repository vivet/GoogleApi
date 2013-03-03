using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    public abstract class MapsBaseRequest : BaseRequest 
	{
        protected internal override string BaseUrl
        {
            get
            {
                return "maps.google.com/maps/api/";
            }
        }
    }
}
