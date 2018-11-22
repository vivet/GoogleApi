using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Places.Details.Request.Enums;

namespace GoogleApi.Entities.Places.Details.Request
{
    /// <summary>
    /// Places Details Request.
    /// </summary>
    public class PlacesDetailsRequest : BasePlacesRequest
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
        /// Fields (optional).
        /// Defaults to 'Basic'.
        /// One or more fields, specifying the types of place data to return, separated by a comma.
        /// Fields correspond to Place Details results, and are divided into three billing categories: Basic, Contact, and Atmosphere.
        /// Basic fields are billed at base rate, and incur no additional charges.Contact and Atmosphere fields are billed at a higher rate.
        /// See the pricing sheet for more information. Attributions (html_attributions) are always returned with every call, regardless of whether it has been requested.
        /// </summary>
        public virtual FieldTypes Fields { get; set; } = FieldTypes.Basic;

        /// <summary>
        /// Extensions (optional) — Indicates if the Place Details response should include additional fields. 
        /// Additional fields may include Premium data, requiring an additional license, or values that are not commonly requested. 
        /// Supported values for the extensions parameter are: ◦review_summary includes a rich and concise review curated by Google's editorial staff.
        /// </summary>
        public virtual Extensions Extensions { get; set; } = Extensions.None;

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

            var fields = Enum.GetValues(typeof(FieldTypes))
                .Cast<FieldTypes>()
                .Where(x => this.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLower()},");

            parameters.Add("fields", fields.EndsWith(",") ? fields.Substring(0, fields.Length - 1) : fields);

            if (!string.IsNullOrEmpty(this.SessionToken))
                parameters.Add("sessiontoken", this.SessionToken);

            if (this.Extensions != Enums.Extensions.None)
                parameters.Add("extensions", this.Extensions.ToString().ToLower());

            return parameters;
        }
    }
}