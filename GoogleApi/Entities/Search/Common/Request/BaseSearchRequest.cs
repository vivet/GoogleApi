using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Search.Common.Enums.Extensions;

namespace GoogleApi.Entities.Search.Common.Request
{
    /// <summary>
    /// Base abstract class for Search requests.
    /// </summary>
    public abstract class BaseSearchRequest : BaseRequest, IQueryStringRequest
    {
        private const string BASE_URL = "www.googleapis.com/customsearch/v1";

        /// <summary>
        /// Use the q query parameter to specify your search expression.
        /// </summary>
        public virtual string Query { get; set; }

        /// <summary>
        /// Define technical aspects of your request, like the API key or data format for the response (JSON or Atom).
        /// </summary>
        public virtual StandardQueryParameters Standard { get; set; } = new StandardQueryParameters();

        /// <summary>
        /// Define properties of your search, like the search expression, number of results, language etc.
        /// </summary>
        public virtual ApiSpecificQueryParameters ApiSpecific { get; set; } = new ApiSpecificQueryParameters();

        /// <summary>
        /// True to use use the https protocol; false to use http. The default is false.
        /// </summary>
        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, SearchRequest must use SSL"); }
        }

        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => BaseSearchRequest.BASE_URL;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParameters GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("ApiKey must be provided");

            if (string.IsNullOrEmpty(this.Query))
                throw new ArgumentException("Query must not null.");

            parameters.Add("q", this.Query);
            parameters.Add("alt", this.Standard.Alt.ToString().ToLower());
            parameters.Add("userIp", this.Standard.UserIp ?? string.Empty);
            parameters.Add("quotaUser", this.Standard.QuotaUser ?? string.Empty);
            parameters.Add("prettyPrint", this.Standard.PrettyPrint.ToString().ToLower());

            // BUG: Implement: Search Request Fields (https://developers.google.com/custom-search/json-api/v1/performance)
            if (this.Standard.Fields != null)
                parameters.Add("fields", this.Standard.Fields);

            parameters.Add("num", this.ApiSpecific.Number.ToString());
            parameters.Add("hl", this.ApiSpecific.InterfaceLanguage.ToHl());
            parameters.Add("gl", this.ApiSpecific.GeoLocation?.ToCr() ?? string.Empty);
            parameters.Add("cr", this.ApiSpecific.CountryRestriction?.ToCr() ?? string.Empty);
            parameters.Add("sort", this.ApiSpecific.SortExpression.ToString());
            parameters.Add("start", this.ApiSpecific.StartIndex.ToString());
            parameters.Add("safe", this.ApiSpecific.SafetyLevel.ToString().ToLower());
            parameters.Add("filter", this.ApiSpecific.Filter ? "0" : "1");
            parameters.Add("c2coff", this.ApiSpecific.DisableCnTwTranslation ? "0" : "1");
            parameters.Add("rights", string.Join(",", this.ApiSpecific.Rights));
            parameters.Add("fileType", string.Join(",", this.ApiSpecific.FileTypes));
            parameters.Add("dateRestrict", this.ApiSpecific.DateRestrictType == null ? string.Empty : this.ApiSpecific.DateRestrictType.ToString().ToLower()[0] + "[" + this.ApiSpecific.DateRestrictNumber.GetValueOrDefault() + "]");

            if (this.ApiSpecific.Googlehost != null)
                parameters.Add("googleHost", this.ApiSpecific.Googlehost);

            if (this.ApiSpecific.SiteSearch != null)
                parameters.Add("siteSearch", this.ApiSpecific.SiteSearch ?? string.Empty);

            if (this.ApiSpecific.SiteSearchFilter != null)
                parameters.Add("siteSearchFilter", this.ApiSpecific.SiteSearchFilter ?? string.Empty);

            if (this.ApiSpecific.ExactTerms != null)
                parameters.Add("exactTerms", this.ApiSpecific.ExactTerms ?? string.Empty);

            if (this.ApiSpecific.ExcludeTerms != null)
                parameters.Add("excludeTerms", this.ApiSpecific.ExcludeTerms ?? string.Empty);

            if (this.ApiSpecific.AndTerms != null)
                parameters.Add("hq", this.ApiSpecific.AndTerms ?? string.Empty);

            if (this.ApiSpecific.OrTerms != null)
                parameters.Add("orTerms", this.ApiSpecific.OrTerms ?? string.Empty);

            if (this.ApiSpecific.LinkSite != null)
                parameters.Add("linkSite", this.ApiSpecific.LinkSite ?? string.Empty);

            if (this.ApiSpecific.RelatedSite != null)
                parameters.Add("relatedSite", this.ApiSpecific.RelatedSite ?? string.Empty);

            if (this.ApiSpecific.LowRange != null)
                parameters.Add("lowRange", this.ApiSpecific.LowRange.ToString());

            if (this.ApiSpecific.HighRange != null)
                parameters.Add("highRange", this.ApiSpecific.HighRange.ToString());

            return parameters;
        }
    }
}