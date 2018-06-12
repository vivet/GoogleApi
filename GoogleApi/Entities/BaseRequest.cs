﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using GoogleApi.Entities.Interfaces;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using GoogleApi.Entities.Common.Extensions;

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
        [JsonIgnore]
        public virtual string Key { get; set; }

        /// <summary>
        /// See <see cref="IRequest.ClientId"/>.
        /// </summary>
        [JsonIgnore]
        public virtual string ClientId { get; set; }

        /// <summary>
        /// See <see cref="IRequest.IsSsl"/>.
        /// </summary>
        [JsonIgnore]
        public virtual bool IsSsl { get; set; } = true;

        /// <summary>
        /// See <see cref="IRequest.IsGzip"/>.
        /// </summary>
        [JsonIgnore]
        public virtual bool IsGzip { get; set; } = false;

        /// <summary>
        /// See <see cref="IRequest.GetUri()"/>.
        /// </summary>
        /// <returns>The <see cref="Uri"/>.</returns>
        public virtual Uri GetUri()
        {
            var scheme = this.IsSsl ? "https://" : "http://";
            var queryString = string.Join("&", this.GetQueryStringParameters().Select(x => Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));
            var uri = new Uri(scheme + this.BaseUrl + "?" + queryString);

            if (this.ClientId == null)
                return uri;

            var url = uri.LocalPath + uri.Query + "&client=" + this.ClientId;
            var bytes = Encoding.UTF8.GetBytes(url);
            var privateKey = Convert.FromBase64String(this.Key.Replace("-", "+").Replace("_", "/"));

            using (var algorithm = new HMACSHA1(privateKey))
            {
                var hash = algorithm.ComputeHash(bytes);
                var base64Signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
                return new Uri(uri.Scheme + "://" + uri.Host + url + "&signature=" + base64Signature);
            }
        }

        /// <summary>
        /// See <see cref="IRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public virtual IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (this.ClientId == null)
            {
                if (!string.IsNullOrWhiteSpace(this.Key))
                    parameters.Add("key", this.Key);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.Key))
                    throw new ArgumentException("Key is required");

                if (!this.ClientId.StartsWith("gme-"))
                    throw new ArgumentException("ClientId must begin with 'gme-'");
            }

            return parameters;
        }
    }
}