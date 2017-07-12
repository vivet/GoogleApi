using System;
using GoogleApi.Extensions;

namespace GoogleApi.Entities
{
    /// <summary>
    /// Base abstract class for requests.
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// Base Url for the request.
        /// </summary>
        protected internal abstract string BaseUrl { get; }

        /// <summary>
        /// Your application's API key (required). 
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app. 
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing. 
        /// All client IDs begin with a "gme-" prefix.
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// True to use use the https protocol; false to use http. 
        /// The default is false.
        /// </summary>
        public virtual bool IsSsl { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        public virtual QueryStringParameters QueryStringParameters
        {
            get
            {
                var parameters = new QueryStringParameters();

                if (this.ClientId == null)
                {
                    if (!string.IsNullOrWhiteSpace(this.Key))
                        parameters.Add("key", this.Key);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.Key))
                        throw new ArgumentException("Key is required.");

                    if (!this.ClientId.StartsWith("gme-"))
                        throw new ArgumentException("ClientId must begin with 'gme-'.");
                }

                return parameters;
            }
        }
    }
}