using System;
using System.Security.Cryptography;
using System.Text;

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
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, Request must use SSL"); }
        }

        /// <summary>
        /// Gets Uri of Signed Request with signature paramter.
        /// </summary>
        /// <returns></returns>
        public override Uri GetUri()
        {
            var uri = base.GetUri();

            return this.ClientId == null ? uri : this.Sign(uri);
        }

        /// <summary>
        /// Signs the request using premium subscription.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected virtual Uri Sign(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Invalid signing key.");

            if (this.ClientId == null)
                throw new NullReferenceException("ClientID");

            if (!this.ClientId.StartsWith("gme-"))
                throw new ArgumentException("A clientId must start with 'gme-'.");

            var urlSegmentToSign = uri.LocalPath + uri.Query + "&client=" + this.ClientId;
            var privateKey = SignableRequest.FromBase64UrlString(this.Key);
            byte[] signature;

            using (var algorithm = new HMACSHA1(privateKey))
            {
                signature = algorithm.ComputeHash(Encoding.ASCII.GetBytes(urlSegmentToSign));
            }

            return new Uri(uri.Scheme + "://" + uri.Host + urlSegmentToSign + "&signature=" + SignableRequest.ToBase64UrlString(signature));
        }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParameters GetQueryStringParameters()
        {
            if (string.IsNullOrEmpty(this.ClientId))
                return base.GetQueryStringParameters();

            var parameters = new QueryStringParameters {{"sensor", Sensor.ToString().ToLower()}};

            return parameters;
        }

        private static string ToBase64UrlString(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_");
        }
        private static byte[] FromBase64UrlString(string base64UrlString)
        {
            if (base64UrlString == null)
                throw new ArgumentNullException(nameof(base64UrlString));

            return Convert.FromBase64String(base64UrlString.Replace("-", "+").Replace("_", "/"));
        }
    }
}