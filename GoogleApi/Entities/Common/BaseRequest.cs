using System;
using System.Security.Cryptography;
using System.Text;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Base abstract class for requests.
    /// </summary>
	public abstract class BaseRequest
    {
        /// <summary>
        /// True to indicate that request comes from a device with a location sensor, otherwise false. 
        /// This information is required by Google and does not affect the results.
        /// </summary>
        /// <remarks>
        /// It is unclear if Google refers to the device performing the request or the source of the location data.
        /// In the geocoding API reference at https://developers.google.com/maps/documentation/geocoding/ the definition is:
        /// 
        ///     sensor (required) — Indicates whether or not the geocoding request comes from a device with a location sensor.
        /// 
        /// This implies that only mobile devices that are equipped with a location sensor (such as GPS) should set the Sensor value 
        /// to True. So if a location is sent to a web server which then calls the Google API, it apparently should set the Sensor
        /// value to false, since the web server isn't a location sensor equipped device.
        /// 
        /// In another page of their documentation, https://developers.google.com/maps/documentation/javascript/tutorial they say:
        /// 
        ///     The sensor parameter of the URL must be included, and indicates whether this application uses a sensor (such as a GPS 
        ///     locator) to determine the user's location.
        /// 
        /// This implies something completely different, that the Sensor value must be set to true if the source of the location
        /// information is a sensor or not, regardless if the request is being performed by a location sensor equipped device or not.
        /// </remarks>
        public bool Sensor { get; set; }
		
        /// <summary>
        /// Your application's API key (required). This key identifies your application for purposes of quota management and so that Places 
        /// added from your application are made immediately available to your app. Visit the APIs Console to create an API Project and obtain your key.
        /// If <see cref="ClientId"/> is specified the key will be signed.
        /// A cryptographic signing key (secret shared key), in base64url format, provided to you by Google Enterprise Support.
        /// The key will only be used if the ClientID property is set, otherwise it will be ignored.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing. 
        /// All client IDs begin with a "gme-" prefix.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// True to use use the https protocol; false to use http. The default is false.
        /// </summary>
        public virtual bool IsSsl { get; set; }

        /// <summary>
        /// Returns the Uri.
        /// If ClientId is set a Signed Uri will be returned.
        /// </summary>
        /// <returns>Uri</returns>
        public virtual Uri GetUri()
		{
            var _scheme = this.IsSsl ? "https://" : "http://";
            var _queryString = this.GetQueryStringParameters().GetQueryStringPostfix();
            var _uri = new Uri(_scheme + this.BaseUrl + "json?" + _queryString);

            return this.ClientId != null ? this.Sign(_uri) : _uri;
		}

        protected internal abstract string BaseUrl { get; }

        protected virtual Uri Sign(Uri _uri)
        {
            if (_uri == null)
                throw new ArgumentNullException("_uri");

            if (this.ClientId == null)
                throw new NullReferenceException("ClientID");

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Invalid signing key.");

            if (!this.ClientId.StartsWith("gme-"))
                throw new ArgumentException("A user ID must start with 'gme-'.");

            var _urlSegmentToSign = _uri.LocalPath + _uri.Query + "&client=" + this.ClientId;
            var _privateKey = BaseRequest.FromBase64UrlString(Key);

            byte[] _signature;
            using (var _algorithm = new HMACSHA1(_privateKey))
            {
                _signature = _algorithm.ComputeHash(Encoding.ASCII.GetBytes(_urlSegmentToSign));
            }

            return new Uri(_uri.Scheme + "://" + _uri.Host + _urlSegmentToSign + "&signature=" + BaseRequest.ToBase64UrlString(_signature));
        }
        protected virtual QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = new QueryStringParametersList();
         
            if(!string.IsNullOrWhiteSpace(this.Key))
                _parameters.Add("key", this.Key);

            _parameters.Add("sensor", Sensor.ToString().ToLower());

            return _parameters;
        }

        private static string ToBase64UrlString(byte[] _data)
        {
            return Convert.ToBase64String(_data).Replace("+", "-").Replace("/", "_");
        }
        private static byte[] FromBase64UrlString(string _base64UrlString)
        {
            return Convert.FromBase64String(_base64UrlString.Replace("-", "+").Replace("_", "/"));
        }
    }
}
