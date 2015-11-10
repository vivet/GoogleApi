using System;
using System.Security.Cryptography;
using System.Text;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// An abstract base class for requests that can be authenticated via URL signing.
    /// </summary>
    /// <remarks>
    /// See https://developers.google.com/maps/documentation/business/webservices for details about signing.
    /// </remarks>
    public abstract class SignableRequest : BaseRequest
    {
        /// <summary>
        /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing. 
        /// All client IDs begin with a "gme-" prefix.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets Uri of Signed Request with signature paramter.
        /// </summary>
        /// <returns></returns>
        public override Uri GetUri()
        {
            return this.ClientId != null ? this.Sign(base.GetUri()) : base.GetUri();
        }

        protected internal Uri Sign(Uri _uri)
        {
            if (_uri == null)
                throw new ArgumentNullException("_uri");

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Invalid signing key.");

            if (this.ClientId == null)
                throw new NullReferenceException("ClientID");

            if (!this.ClientId.StartsWith("gme-"))
                throw new ArgumentException("A user ID must start with 'gme-'.");

            var _urlSegmentToSign = _uri.LocalPath + _uri.Query + "&client=" + this.ClientId;
            var _privateKey = SignableRequest.FromBase64UrlString(this.Key);
            byte[] _signature;

            using (var _algorithm = new HMACSHA1(_privateKey))
            {
                _signature = _algorithm.ComputeHash(Encoding.ASCII.GetBytes(_urlSegmentToSign));
            }

            return new Uri(_uri.Scheme + "://" + _uri.Host + _urlSegmentToSign + "&signature=" + SignableRequest.ToBase64UrlString(_signature));
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = new QueryStringParametersList();

            _parameters.Add("sensor", Sensor.ToString().ToLower());

            return _parameters;
        }

        private static string ToBase64UrlString(byte[] _data)
        {
            if (_data == null) 
                throw new ArgumentNullException("_data");

            return Convert.ToBase64String(_data).Replace("+", "-").Replace("/", "_");
        }

        private static byte[] FromBase64UrlString(string _base64UrlString)
        {
            if (_base64UrlString == null) 
                throw new ArgumentNullException("_base64UrlString");
            
            return Convert.FromBase64String(_base64UrlString.Replace("-", "+").Replace("_", "/"));
        }
    }
}