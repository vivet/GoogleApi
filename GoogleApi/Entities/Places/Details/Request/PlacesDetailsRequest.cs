using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.Details.Request
{
    /// <summary>
    /// Places Details Request.
    /// </summary>
    public class PlacesDetailsRequest : BasePlacesRequest, IQueryStringRequest
    {
        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "details/json";

        /// <summary>
        /// A textual identifier that uniquely identifies a place, returned from a Place Search.
        /// </summary>
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Language (optional) — The language code, indicating in which language the results should be returned, if possible. See the list of supported languages and their codes. Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// Extensions (optional) — Indicates if the Place Details response should include additional fields. Additional fields may include Premium data, requiring an additional license, or values that are not commonly requested. Supported values for the extensions parameter are: ◦review_summary includes a rich and concise review curated by Google's editorial staff.
        /// </summary>
        public virtual Enums.Extensions Extensions { get; set; } = Enums.Extensions.None;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PlaceId))
                    throw new ArgumentException("PlaceId must be provided.");

                var parameters = base.QueryStringParameters;

                parameters.Add("placeid", this.PlaceId);

                if (this.Extensions != Enums.Extensions.None)
                    parameters.Add("extensions", this.Extensions.ToString().ToLower());

                if (!string.IsNullOrWhiteSpace(this.Language))
                    parameters.Add("language", this.Language);

                return parameters;
            }
        }
    }
}