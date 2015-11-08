using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places requests.
    /// </summary>
    public abstract class BasePlacesRequest : BaseRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/place/";

        /// <summary>
        /// Your application's API key (required). This key identifies your application for purposes of quota management and so that Places 
        /// added from your application are made immediately available to your app. Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        public virtual string ApiKey { get; set; }

        protected internal override string BaseUrl
        {
            get
            {
                return BasePlacesRequest.BASE_URL;
            }
        }
    }
}