using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class BaseMapsRequest : BaseRequest
    {
        private const string BASE_URL = "maps.google.com/maps/api/";

        /// <summary>
        /// A cryptographic signing key (secret shared key), in base64url format, provided to you by Google Enterprise Support.
        /// The key will only be used if the ClientID property is set, otherwise it will be ignored.
        /// </summary>
        /// <remarks>
        /// This cryptographic signing key is not the same as the (freely available) Maps API key (typically beginning with 'ABQ..') 
        /// that developers without a Maps API for Business license are required to use when loading the Maps JavaScript API V2 and 
        /// Maps API for Flash, or the keys issued by the Google APIs Console for use with the Google Places API.
        /// </remarks>
        public string SigningKey { get; set; }



        protected internal override string BaseUrl
        {
            get
            {
                return BaseMapsRequest.BASE_URL;
            }
        }
    }
}
