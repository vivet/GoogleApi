using System;
using System.Net;

namespace GoogleApi.Engine
{
    /// <summary>
    /// Base class for facade engine.
    /// </summary>
    public abstract class GenericEngine
    {
        protected const string AUTHENTICATION_FAILED_MESSAGE = "The request to Google API failed with HTTP error '(403) Forbidden', which usually indicates that the provided client ID or signing key is invalid or expired.";

        protected static ServicePoint HttpServicePoint { get; set; }
        protected static ServicePoint HttpsServicePoint { get; set; }
  
        protected static bool IndicatesAuthenticationFailed(Exception _ex)
        {
            var _webException = _ex as WebException;
            return _webException != null && _webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)_webException.Response).StatusCode == HttpStatusCode.Forbidden;
        }

        /// <summary>
        /// Determines the maximum number of concurrent HTTP connections to open to this engine's host address. The default value is 2 connections.
        /// </summary>
        /// <remarks>
        /// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
        /// </remarks>
        public static int HttpConnectionLimit
        {
            get
            {
                return GenericEngine.HttpServicePoint.ConnectionLimit;
            }
            set
            {
                GenericEngine.HttpServicePoint.ConnectionLimit = value;
            }
        }

        /// <summary>
        /// Determines the maximum number of concurrent HTTPS connections to open to this engine's host address. The default value is 2 connections.
        /// </summary>
        /// <remarks>
        /// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
        /// </remarks>
        public static int HttpsConnectionLimit
        {
            get
            {
                return GenericEngine.HttpsServicePoint.ConnectionLimit;
            }
            set
            {
                GenericEngine.HttpsServicePoint.ConnectionLimit = value;
            }
        }
    }
}