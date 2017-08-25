using System;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using GoogleApi.Entities.Search.Common.Request;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Base abstract class for Search requests.
    /// </summary>
    public abstract class BaseSearchRequest : BaseRequest, IRequestQueryString
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/customsearch/v1";

        /// <summary>
        /// Required. 
        /// Use the q query parameter to specify your search expression.
        /// </summary>
        public virtual string Query { get; set; }

        /// <summary>
        /// Required. 
        /// Search engine created for a site with the Google Control Panel 
        /// To create a Google Custom Search engine that searches the entire web:
        /// 1. From the Google Custom Search homepage (http://www.google.com/cse), click Create a Custom Search Engine.
        /// 2. Type a name and description for your search engine.
        /// 3. Under Define your search engine, in the Sites to Search box, enter at least one valid URL (For now, just put www.anyurl.com to get past this screen.More on this later).
        /// 4. Select the CSE edition you want and accept the Terms of Service, then click Next.Select the layout option you want, and then click Next.
        /// 5. Click any of the links under the Next steps section to navigate to your Control panel.
        /// 6. In the left-hand menu, under Control Panel, click Basics.
        /// 7. In the Search Preferences section, select Search the entire web but emphasize included sites.
        /// 8. Click Save Changes.
        /// 9. In the left-hand menu, under Control Panel, click Sites.
        /// 10. Delete the site you entered during the initial setup process.
        /// 11. Now your custom search engine will search the entire web.
        /// </summary>
        public virtual string SearchEngineId { get; set; }

        /// <summary>
        /// Alt - Data format for the response. (only json supported)
        /// Valid values: json, atom
        /// Default value: json
        /// </summary>
        public virtual AltType Alt { get; } = AltType.Json;

        /// <summary>
        /// fields - Selector specifying a subset of fields to include in the response.	
        /// For more information, see the partial response section in the Performance Tips document.
        /// Use for better performance. https://developers.google.com/custom-search/json-api/v1/performance#partial
        /// </summary>
        public virtual string Fields { get; set; }

        /// <summary>
        /// userIp IP address of the end user for whom the API call is being made.	
        /// Lets you enforce per-user quotas when calling the API from a server-side application.
        /// Learn more about Capping API usage. https://support.google.com/cloud/answer/7035610
        /// </summary>
        public virtual string UserIp { get; set; }

        /// <summary>
        /// quotaUser Alternative to userIp.	
        /// Lets you enforce per-user quotas from a server-side application even in cases when the user's IP address is unknown. This can occur, for example, with applications that run cron jobs on App Engine on a user's behalf.
        /// You can choose any arbitrary string that uniquely identifies a user, but it is limited to 40 characters.
        /// Overrides userIp if both are provided.
        /// Learn more about Capping API usage. https://support.google.com/cloud/answer/7035610
        /// </summary>
        public virtual string QuotaUser { get; set; }

        /// <summary>
        /// PrettyPrint - Returns response with indentations and line breaks.
        /// Returns the response in a human-readable format if true.
        /// Default value: true.
        /// When this is false, it can reduce the response payload size, which might lead to better performance in some environments.
        /// </summary>
        public virtual bool PrettyPrint { get; set; } = true;

        /// <summary>
        /// Define properties of your search, like the search expression, number of results, language etc.
        /// </summary>
        public virtual SearchOptions Options { get; set; } = new SearchOptions();

        /// <summary>
        /// True to use use the https protocol; false to use http. The default is false.
        /// </summary>
        public override bool IsSsl
        {
            get => true;
            set => throw new NotSupportedException("This operation is not supported, SearchRequest must use SSL");
        }

        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Key is required");

            if (string.IsNullOrEmpty(this.Query))
                throw new ArgumentException("Query is required");

            if (string.IsNullOrEmpty(this.SearchEngineId))
                throw new ArgumentException("SearchEngineId is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("q", this.Query);
            parameters.Add("cx", this.SearchEngineId);
            parameters.Add("alt", this.Alt.ToString().ToLower());
            parameters.Add("userIp", this.UserIp ?? string.Empty);
            parameters.Add("quotaUser", this.QuotaUser ?? string.Empty);
            parameters.Add("prettyPrint", this.PrettyPrint.ToString().ToLower());

            if (this.Fields != null)
                parameters.Add("fields", this.Fields);

            parameters.Add("hl", this.Options.InterfaceLanguage.ToHl());
            parameters.Add("gl", this.Options.GeoLocation?.ToCr() ?? string.Empty);
            parameters.Add("cr", this.Options.CountryRestriction?.ToCr() ?? string.Empty);
            parameters.Add("sort", this.Options.SortExpression.ToString());
            parameters.Add("start", this.Options.StartIndex.ToString());
            parameters.Add("safe", this.Options.SafetyLevel.ToString().ToLower());
            parameters.Add("filter", this.Options.Filter ? "0" : "1");
            parameters.Add("c2coff", this.Options.DisableCnTwTranslation ? "0" : "1");
            parameters.Add("rights", string.Join(",", this.Options.Rights));
            parameters.Add("fileType", string.Join(",", this.Options.FileTypes));
            parameters.Add("dateRestrict", this.Options.DateRestrict == null 
                ? string.Empty 
                : this.Options.DateRestrict.Type.ToString().ToLower()[0] + "[" + this.Options.DateRestrict.Number + "]");

            if (this.Options.SearchType != SearchType.Web)
                parameters.Add("searchType", this.Options.SearchType.ToString().ToLower());

            if (this.Options.Number != null)
                parameters.Add("num", this.Options.Number.ToString());

            if (this.Options.Googlehost != null)
                parameters.Add("googleHost", this.Options.Googlehost);

            if (this.Options.SiteSearch != null)
                parameters.Add("siteSearch", this.Options.SiteSearch ?? string.Empty);

            if (this.Options.SiteSearchFilter != null)
                parameters.Add("siteSearchFilter", this.Options.SiteSearchFilter ?? string.Empty);

            if (this.Options.ExactTerms != null)
                parameters.Add("exactTerms", this.Options.ExactTerms ?? string.Empty);

            if (this.Options.ExcludeTerms != null)
                parameters.Add("excludeTerms", this.Options.ExcludeTerms ?? string.Empty);

            if (this.Options.AndTerms != null)
                parameters.Add("hq", this.Options.AndTerms ?? string.Empty);

            if (this.Options.OrTerms != null)
                parameters.Add("orTerms", this.Options.OrTerms ?? string.Empty);

            if (this.Options.LinkSite != null)
                parameters.Add("linkSite", this.Options.LinkSite ?? string.Empty);

            if (this.Options.RelatedSite != null)
                parameters.Add("relatedSite", this.Options.RelatedSite ?? string.Empty);

            if (this.Options.LowRange != null)
                parameters.Add("lowRange", this.Options.LowRange.ToString());

            if (this.Options.HighRange != null)
                parameters.Add("highRange", this.Options.HighRange.ToString());

            return parameters;
        }
    }
}