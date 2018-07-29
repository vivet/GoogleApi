using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Places.Details.Request
{
    /// <summary>
    /// Places Details Request.
    /// </summary>
    public class PlacesDetailsRequest : BasePlacesRequest, IRequestQueryString
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "details/json";

        /// <summary>
        /// A textual identifier that uniquely identifies a place, returned from a Place Search.
        /// </summary>
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// A random string which identifies an autocomplete session for billing purposes.
        /// Use this for Place Details requests that are called following an autocomplete request in the same user session
        /// </summary>
        public virtual string SessionToken { get; set; }

        /// <summary>
        /// Language (optional) — The language code, indicating in which language the results should be returned, if possible. 
        /// See the list of supported languages and their codes: https://developers.google.com/maps/faq#languagesupport
        /// Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// Extensions (optional) — Indicates if the Place Details response should include additional fields. 
        /// Additional fields may include Premium data, requiring an additional license, or values that are not commonly requested. 
        /// Supported values for the extensions parameter are: ◦review_summary includes a rich and concise review curated by Google's editorial staff.
        /// </summary>
        public virtual Enums.Extensions Extensions { get; set; } = Enums.Extensions.None;

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.PlaceId))
                throw new ArgumentException("PlaceId is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("placeid", this.PlaceId);
            parameters.Add("language", this.Language.ToCode());

            if (!string.IsNullOrEmpty(this.SessionToken))
                parameters.Add("sessiontoken", this.SessionToken);

            if (this.Extensions != Enums.Extensions.None)
                parameters.Add("extensions", this.Extensions.ToString().ToLower());

            return parameters;
        }
    }
}