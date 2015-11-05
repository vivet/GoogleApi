using System;
using System.Security.Cryptography;
using System.Text;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Common
{
	/// <summary>
	/// An abstract base class for requests that can be authenticated via URL signing.
	/// </summary>
	/// <remarks>
	/// See https://developers.google.com/maps/documentation/business/webservices for details about signing.
	/// </remarks>
	public abstract class SignableRequest : MapsBaseRequest
    {
		/// <summary>
		/// The client ID provided to you by Google Enterprise Support, or null to disable URL signing. 
		/// All client IDs begin with a "gme-" prefix.
		/// </summary>
		public string ClientId { get; set; }
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

        /// <summary>
        /// Gets Uri of Signed Request with signature paramter.
        /// </summary>
        /// <returns></returns>
		public override Uri GetUri()
		{
            return this.ClientId != null ? this.Sign(base.GetUri()) : base.GetUri();
		}

		protected Uri Sign(Uri _uri)
		{
            if (_uri == null)
				throw new ArgumentNullException("_uri");

            if (this.ClientId == null)
                throw new NullReferenceException("ClientID");

            if (string.IsNullOrWhiteSpace(this.SigningKey))
				throw new ArgumentException("Invalid signing key.");

            if (!this.ClientId.StartsWith("gme-"))
				throw new ArgumentException("A user ID must start with 'gme-'.");

            var _urlSegmentToSign = _uri.LocalPath + _uri.Query + "&client=" + this.ClientId;
			var _privateKey = SignableRequest.FromBase64UrlString(SigningKey);
		
            byte[] _signature;
			using (var _algorithm = new HMACSHA1(_privateKey))
			{
				_signature = _algorithm.ComputeHash(Encoding.ASCII.GetBytes(_urlSegmentToSign));
			}

            return new Uri(_uri.Scheme + "://" + _uri.Host + _urlSegmentToSign + "&signature=" + SignableRequest.ToBase64UrlString(_signature));
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
