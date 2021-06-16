using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Request
{
    /// <summary>
    /// Plus Code Request.
    /// </summary>
    public class PlusCodeGeocodeRequest : BaseRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => "plus.codes/api";

        /// <summary>
        /// The Address.
        /// The address to encode. This can be any of the following (if the ekey parameter is also provided):
        /// - A latitude/longitude
        /// - A street address
        /// - A global code
        /// - A local code and locality
        /// </summary>
        public virtual Location Address { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results. 
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// Email.
        /// Provide an email address that can be used to contact you.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Use Encrypted Key.
        /// The request will send the 'ekey' parameter instead of 'key'.
        /// See https://github.com/google/open-location-code/wiki/Plus-codes-API#securing-your-api-key
        /// </summary>
        public virtual bool UseEncryptedKey { get; set; } = false;

        /// <summary>
        /// See <see cref="BaseGeocodeRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(this.Key))
            {
                parameters.Add(this.UseEncryptedKey ? "ekey" : "key", this.Key);
            }

            if (this.Address == null)
                throw new ArgumentException($"{nameof(this.Address)} is required");
            
            parameters.Add("address", this.Address.ToString());
            parameters.Add("language", this.Language.ToCode());

            if (!string.IsNullOrEmpty(this.Email))
            {
                parameters.Add("email", this.Email);
            }

            return parameters;
        }
    }
}