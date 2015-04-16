using System;
using System.Net;

namespace GoogleApi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class WebClientEx : WebClient
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WebClientEx() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public WebClientEx(TimeSpan timeout)
        {
            if (timeout != WebClientExtensionMethods.InfiniteTimeout && timeout <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("timeout", timeout, "The specified timeout must be greater than zero or infinite.");

            Timeout = timeout;
        }

        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </returns>
        /// <param name="address">A <see cref="T:System.Uri"/> that identifies the resource to request.</param>
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);

            if (request != null && Timeout != null)
                request.Timeout = (int)Timeout.Value.TotalMilliseconds;

            return request;
        }
    }
}
