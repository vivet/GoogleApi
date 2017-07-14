using System;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Interfaces;

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
        /// Language (optional) — The language code, indicating in which language the results should be returned, if possible. 
        /// See the list of supported languages and their codes. Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// Extensions (optional) — Indicates if the Place Details response should include additional fields. 
        /// Additional fields may include Premium data, requiring an additional license, or values that are not commonly requested. 
        /// Supported values for the extensions parameter are: ◦review_summary includes a rich and concise review curated by Google's editorial staff.
        /// </summary>
        public virtual Enums.Extensions Extensions { get; set; } = Enums.Extensions.None;

        /// <summary>
        /// See <see cref="BasePlacesRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> colletion.</returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PlaceId))
                    throw new ArgumentException("PlaceId must be provided");

                var parameters = base.QueryStringParameters;

                parameters.Add("placeid", this.PlaceId);
                parameters.Add("language", this.Language.ToCode());

                if (this.Extensions != Enums.Extensions.None)
                    parameters.Add("extensions", this.Extensions.ToString().ToLower());

                return parameters;
            }
        }
    }
}