using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.Geocoding
{
    /// <summary>
    /// Base Geocoding Request.
    /// </summary>
    public abstract class BaseGeocodeRequest : BaseMapsChannelRequest, IRequestQueryString
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "geocode/json";

        /// <summary>
        /// language (optional) — The language in which to return results. 
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// See <see cref="BaseMapsChannelRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{T}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            parameters.Add("language", this.Language.ToCode());

            return parameters;
        }
    }
}