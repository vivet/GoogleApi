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
        /// <param name="_timeout"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public WebClientTimeout(TimeSpan _timeout)
        {
            this.Timeout = _timeout;
        }

        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </returns>
        /// <param name="_uri">A <see cref="T:System.Uri"/> that identifies the resource to request.</param>
        protected override WebRequest GetWebRequest(Uri _uri)
        {
            if (_uri == null) 
                throw new ArgumentNullException(nameof(_uri));
            
            var _request = base.GetWebRequest(_uri);
            
            if (_request == null)
                return null;

            _request.Timeout = this.Timeout == null ? _request.Timeout : (int)this.Timeout.Value.TotalMilliseconds;

            return _request;
        }
    }
}
