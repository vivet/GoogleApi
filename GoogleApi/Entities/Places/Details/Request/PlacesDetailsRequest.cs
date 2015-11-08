using System;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Details.Request
{
    /// <summary>
    /// Places Details Request.
    /// </summary>
    public class PlacesDetailsRequest : BasePlacesRequest
    {
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
        public virtual Enums.Extensions Extensions { get; set; }

        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, PlacesRequest must use SSL"); }
        }

        public PlacesDetailsRequest()
        {
            this.Extensions = Enums.Extensions.NONE;
        }

        protected internal override string BaseUrl
        {
            get { return base.BaseUrl + "details/"; }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.PlaceId))
                throw new ArgumentException("PlaceId must be provided.");

            _parameters.Add("placeid", this.PlaceId);

            if (this.Extensions != Enums.Extensions.NONE)
                _parameters.Add("extensions", this.Extensions.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(this.Language)) 
                _parameters.Add("language", this.Language);
            
            return _parameters;
        }
    }
}