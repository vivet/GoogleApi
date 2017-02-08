using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using GoogleApi.Entities.Search.Common.Response.Enums;
using GoogleApi.Helpers;

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
        /// Number of search results to return.
        /// Valid values are integers between 1 and 10, inclusive.
        /// </summary>
        public virtual int Number { get; set; }

        /// <summary>
        /// PrettyPrint - Returns response with indentations and line breaks.
        /// Returns the response in a human-readable format if true.
        /// Default value: true.
        /// When this is false, it can reduce the response payload size, which might lead to better performance in some environments.
        /// </summary>
        public virtual bool PrettyPrint { get; set; } = true;

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
        /// The URL of a linked custom search engine specification to use for this request. 
        /// Default Google search engine.
        /// </summary>
        public virtual string SearchEngineUrl { get; set; }

        /// <summary>
        /// Alt - Data format for the response.
        /// Valid values: json, atom
        /// Default value: json
        /// </summary>
        public virtual AltType Alt { get; set; } = AltType.Json;

        /// <summary>
        /// fields - Selector specifying a subset of fields to include in the response.	
        /// For more information, see the partial response section in the Performance Tips document.
        /// Use for better performance. https://developers.google.com/custom-search/json-api/v1/performance#partial
        /// </summary>
        public virtual string Fields { get; set; }

        /// <summary>
        /// Language - Sets the user interface language. 
        /// Explicitly setting this parameter improves the performance and the quality of your search results.
        /// See the Interface Languages section of Internationalizing Queries and Results Presentation for more information, 
        /// and Supported Interface Languages for a list of supported languages.
        /// https://developers.google.com/custom-search/docs/xml_results#interfaceLanguages
        /// </summary>
        public virtual Language InterfaceLanguage { get; set; } = Language.English;

        /// <summary>
        /// Geolocation of end user.
        /// The geolocation parameter value is a two-letter country code.The gl parameter boosts search results whose country of origin matches the parameter value.
        /// See the Country Codes page for a list of valid values. https://developers.google.com/custom-search/docs/xml_results#countryCodes
        /// Specifying a geolocation parameter value should lead to more relevant results.
        /// This is particularly true for international customers and, even more specifically, for customers in English- speaking countries other than the United States.
        /// </summary>
        public virtual Country? GeoLocation { get; set; }

        /// <summary>
        /// Restricts search results to documents originating in a particular country. 
        /// You may use Boolean operators in the cr parameter's value.
        /// Google Search determines the country of a document by analyzing:
        /// the top-level domain(TLD) of the document's URL  the geographic location of the Web server's IP address
        /// See the Country Parameter Values page for a list of valid values for this parameter.
        /// https://developers.google.com/custom-search/docs/xml_results_appendices#countryCollections
        /// </summary>
        public virtual Country? CountryRestriction { get; set; }

        /// <summary>
        /// Filter - Controls turning on or off the duplicate content filter.
        /// See Automatic Filtering for more information about Google's search results filters. 
        /// Note that host crowding filtering applies only to multi-site searches.
        /// By default, Google applies filtering to all search results to improve the quality of those results.
        /// https://developers.google.com/custom-search/docs/xml_results#automaticFiltering.
        /// </summary>
        public virtual bool Filter { get; set; } = true;

        /// <summary>
        /// Enables or disables the Simplified and Traditional Chinese Search feature.
        /// The default value for this parameter is true, meaning that the feature is enabled.
        /// </summary>
        public virtual bool DisableCnTwTranslation { get; set; } = true;

        /// <summary>
        /// Googlehost - The local Google domain (for example, google.com, google.de, or google.fr) to use to perform the search.
        /// </summary>
        public virtual string Googlehost { get; set; }

        /// <summary>
        /// SiteSearch - Specifies all search results should be pages from a given site.
        /// </summary>
        public virtual string SiteSearch { get; set; }

        /// <summary>
        /// SiteSearchFilter - Controls whether to include or exclude results from the site named in the siteSearch parameter.
        /// Acceptable values are:
        /// - "e": exclude
        /// - "i": include
        /// </summary>
        public virtual string SiteSearchFilter { get; set; }

        /// <summary>
        /// ExactTerms - Identifies a phrase that all documents in the search results must contain.
        /// </summary>
        public virtual string ExactTerms { get; set; }

        /// <summary>
        /// ExactTerms - Identifies a word or phrase that should not appear in any documents in the search results.
        /// </summary>
        public virtual string ExcludeTerms { get; set; }

        /// <summary>
        /// OrTerms - Provides additional search terms to check for in a document, 
        /// where each document in the search results must contain at least one of the additional search terms.
        /// </summary>
        public virtual string OrTerms { get; set; }

        /// <summary>
        /// AndTerms - string Appends the specified query terms to the query, as if they were combined with a logical AND operator.
        /// </summary>
        public virtual string AndTerms { get; set; }

        /// <summary>
        /// LinkSite - Specifies that all search results should contain a link to a particular URL.
        /// </summary>
        public virtual string LinkSite { get; set; }

        /// <summary>
        /// RelatedSite - Specifies that all search results should be pages that are related to the specified URL.
        /// </summary>
        public virtual string RelatedSite { get; set; }

        /// <summary>
        /// Sort - The sort expression to apply to the results.
        /// </summary>
        public virtual SortOrder Sort { get; set; } = SortOrder.Asc;

        /// <summary>
        /// Start - The index of the first result to return.
        /// </summary>
        public virtual int StartIndex { get; set; }

        /// <summary>
        /// SafetyLevel - Search safety level.
        /// Acceptable values are:
        /// - "off": Disables SafeSearch filtering. (default)
        ///-  "medium": Enables moderate SafeSearch filtering.
        /// - "high": Enables highest level of SafeSearch filtering.
        /// </summary>
        public virtual SafetyLevel SafetyLevel { get; set; } = SafetyLevel.Off;

        /// <summary>
        /// Rights - Filters based on licensing.
        /// Supported values include: cc_publicdomain, cc_attribute, cc_sharealike, cc_noncommercial, cc_nonderived, and combinations of these.
        /// </summary>
        public virtual IEnumerable<RightsType> Rights { get; set; }

        /// <summary>
        /// FileType - Restricts results to files of a specified extension.
        /// A list of file types indexable by Google can be found in Search Console Help Center. https://support.google.com/webmasters/answer/35287?hl=en
        /// </summary>
        public virtual IEnumerable<FileType> FileTypes { get; set; }

        /// <summary>
        /// DateRestrict - Restricts results to URLs based on date.
        /// </summary>
        public virtual DateRestrictType? DateRestrictType { get; set; }

        /// <summary>
        /// DateRestrictNumber - Requests results from the specified number of past days, weeks, months or years.
        /// </summary>
        public virtual int? DateRestrictNumber { get; set; }

        /// <summary>
        /// Allowed values are web or image. If unspecified, results are limited to webpages.
        /// </summary>
        public virtual SearchType SearchType { get; set; } = SearchType.Web;

        /// <summary>
        /// LowRange - Specifies the starting value for a search range.
        /// Use lowRange and highRange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        public virtual int LowRange { get; set; }

        /// <summary>
        /// HighRange - Specifies the ending value for a search range.
        /// Use lowRange and highRange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        public virtual int HighRange { get; set; }

        /// <summary>
        /// True to use use the https protocol; false to use http. The default is false.
        /// </summary>
        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, PlacesRequest must use SSL"); }
        }

        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => BaseSearchRequest.BASE_URL;
        
        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();
            
            if (string.IsNullOrEmpty(this.Query))
                throw new NullReferenceException("this.Query");

            if (string.IsNullOrEmpty(this.SearchEngineUrl))
                throw new NullReferenceException("this.SearchEngineUrl");

            parameters.Add("q", this.Query);
            parameters.Add("number", this.Number.ToString());
            parameters.Add("prettyPrint", this.PrettyPrint.ToString().ToLower());

            if (!string.IsNullOrEmpty(this.UserIp))
                parameters.Add("userIp", this.UserIp);

            if (!string.IsNullOrEmpty(this.QuotaUser))
                parameters.Add("quotaUser", this.QuotaUser);

            parameters.Add("cref", this.SearchEngineUrl);
            parameters.Add("alt", this.Alt.ToString().ToLower());

            if (this.Fields != null)
                parameters.Add("fields", this.Fields);

            parameters.Add("hl", this.InterfaceLanguage.ToHl());

            if (this.GeoLocation != null)
                parameters.Add("gl", this.GeoLocation.Value.ToCr());

            if (this.CountryRestriction != null)
                parameters.Add("cr", this.CountryRestriction.Value.ToCr());

            parameters.Add("filter", this.Filter ? "0" : "1");
            parameters.Add("c2coff", this.DisableCnTwTranslation ? "0" : "1");

            if (this.Googlehost != null)
                parameters.Add("googleHost", this.Googlehost);

            if (this.SiteSearch != null)
                parameters.Add("siteSearch", this.SiteSearch);

            if (this.SiteSearchFilter != null)
                parameters.Add("siteSearchFilter", this.SiteSearchFilter);

            if (this.ExactTerms != null)
                parameters.Add("exactTerms", this.ExactTerms);

            if (this.ExcludeTerms != null)
                parameters.Add("excludeTerms", this.ExcludeTerms);

            if (this.AndTerms != null)
                parameters.Add("hq", this.AndTerms);

            if (this.OrTerms != null)
                parameters.Add("orTerms", this.OrTerms);

            if (this.LinkSite != null)
                parameters.Add("linkSite", this.LinkSite);

            if (this.RelatedSite != null)
                parameters.Add("relatedSite", this.RelatedSite);

            parameters.Add("sort", this.Sort.ToString().ToLower());
            parameters.Add("start", this.StartIndex.ToString());
            parameters.Add("safe", this.SafetyLevel.ToString());
            parameters.Add("rights", string.Join(",", this.Rights));
            parameters.Add("fileType", string.Join(",", this.FileTypes));
            parameters.Add("dateRestrict", this.DateRestrictType?.ToString()?[0] + "[" + this.DateRestrictNumber.GetValueOrDefault() + "]");
            parameters.Add("searchType", this.SearchType.ToString().ToLower());
            parameters.Add("lowRange", this.LowRange.ToString());
            parameters.Add("highRange", this.HighRange.ToString());

            return parameters;
        }
    }
}