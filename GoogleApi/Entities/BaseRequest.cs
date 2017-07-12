using System;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities
{
    /// <summary>
    /// Base abstract class for requests.
    /// </summary>
    public abstract class BaseRequest : IRequest
    {
        /// <summary>
        /// Base Url (abstract).
        /// </summary>
        protected internal abstract string BaseUrl { get; }

        /// <summary>
        /// See <see cref="IRequest.Key"/>.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// See <see cref="IRequest.ClientId"/>.
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// See <see cref="IRequest.IsSsl"/>.
        /// </summary>
        public virtual bool IsSsl { get; set; }

        /// <summary>
        /// See <see cref="IRequest.QueryStringParameters"/>.
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