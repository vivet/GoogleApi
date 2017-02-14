using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class BaseMapsRequest : SignableRequest
    {
        private const string BASE_URL = "maps.google.com/maps/api/";

        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => BaseMapsRequest.BASE_URL;
    }
}