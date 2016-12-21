using System;
using System.Net;

namespace GoogleApi.Extensions
{
    /// <summary>
    /// WebClient class.
    /// </summary>
    public class WebClientEx : WebClient
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WebClientEx()
        {
            
        }
        /// <summary>
        /// Constructor, setting custom timeout.
        /// </summary>
        /// <param name="_timeout"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public WebClientEx(TimeSpan _timeout)
        {
            if (_timeout != WebClientExtension._infiniteTimeout && _timeout <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("_timeout", _timeout, "The specified timeout must be greater than zero or infinite.");

            this.Timeout = _timeout;
        }

        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </returns>
        /// <param name="_address">A <see cref="T:System.Uri"/> that identifies the resource to request.</param>
        protected override WebRequest GetWebRequest(Uri _address)
        {
            var _request = base.GetWebRequest(_address);

            if (_request == null)
                return null;

            _request.Timeout = this.Timeout == null ? _request.Timeout : (int)Timeout.Value.TotalMilliseconds;

            return _request;
        }
    }
}
