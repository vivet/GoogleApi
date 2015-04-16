using System;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.PlacesDetails.Request
{
    public class PlacesDetailsRequest : PlacesBaseRequest
    {
        protected internal override string BaseUrl
        {
            get { return base.BaseUrl + "details/"; }
        }

        /// <summary>
        /// Key (required) — Your application's API key. This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app. Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        public virtual string ApiKey { get; set; }

        /// <summary>
        /// Reference (required) — A textual identifier that uniquely identifies a place, returned from a Place search or place autocomplete search.
        /// </summary>
        public virtual string Reference { get; set; }

        /// <summary>
        /// Language (optional) — The language code, indicating in which language the results should be returned, if possible. See the list of supported languages and their codes. Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// Extensions (optional) — Indicates if the Place Details response should include additional fields. Additional fields may include Premium data, requiring an additional license, or values that are not commonly requested. Supported values for the extensions parameter are: ◦review_summary includes a rich and concise review curated by Google's editorial staff.
        /// </summary>
        public virtual Enums.Extensions Extensions { get; set; }

        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, PlacesRequest must use SSL"); }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(Reference))
                throw new ArgumentException("Reference must be provided.");

            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("ApiKey must be provided");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("reference", Reference);
            parameters.Add("key", ApiKey);

            if (!string.IsNullOrWhiteSpace(Language)) 
                parameters.Add("language", Language);

            // TODO: fails with REQUEST_DENIED
            //if (!string.IsNullOrWhiteSpace(this.Language))
            //    _parameters.Add("extensions", this.Extensions.ToString().ToLower());
            
            return parameters;
        }
    }
}