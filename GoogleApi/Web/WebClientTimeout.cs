using System;
using System.Net;

namespace GoogleApi.Web
{
    /// <summary>
    /// WebClient class.
    /// </summary>
    public class WebClientTimeout : WebClient
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Constructor, setting custom timeout.
        /// </summary>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public WebClientTimeout(TimeSpan timeout)
        {
            this.Timeout = timeout;
        }

        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </returns>
        /// <param name="uri">A <see cref="T:System.Uri"/> that identifies the resource to request.</param>
        protected override WebRequest GetWebRequest(Uri uri)
        {
            if (uri == null) 
                throw new ArgumentNullException(nameof(uri));
            
            var request = base.GetWebRequest(uri);
            
            if (request == null)
                return null;

            request.Timeout = this.Timeout == null ? request.Timeout : (int)this.Timeout.Value.TotalMilliseconds;

            return request;
        }
    }
}
