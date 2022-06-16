using System.Collections.Generic;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Search.Common.Converters;
using GoogleApi.Entities.Search.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Query Information.
    /// </summary>
    public class QueryInfo
    {
        /// <summary>
        /// A description of the query.
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// Estimated number of total search results. May not be accurate.
        /// </summary>
        [JsonProperty("totalResults")]
        public virtual long TotalResults { get; set; }

        /// <summary>
        /// The search terms entered by the user.
        /// </summary>
        [JsonProperty("searchTerms")]
        public virtual string SearchTerms { get; set; }

        /// <summary>
        /// Number of search results returned in this set.
        /// </summary>
        [JsonProperty("count")]
        public virtual int Count { get; set; }

        /// <summary>
        /// Start - The index of the first result to return.
        /// </summary>
        [JsonProperty("startIndex")]
        public virtual int StartIndex { get; set; }

        /// <summary>
        /// The page number of this set of results, where the page length is set by the count property.
        /// </summary>
        [JsonProperty("startPage")]
        public virtual int StartPage { get; set; }

        /// <summary>
        /// The language of the search results.
        /// </summary>
        [JsonProperty("language")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Language? Language { get; set; }

        /// <summary>
        /// The character encoding supported for search request.
        /// </summary>
        [JsonProperty("inputEncoding")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual EncodingType? InputEncoding { get; set; }

        /// <summary>
        /// The character encoding supported for search results.
        /// </summary>
        [JsonProperty("outputEncoding")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual EncodingType? OutputEncoding { get; set; }

        /// <summary>
        /// Specifies the SafeSearch level used for filtering out adult results.
        /// This is a custom property not defined in the OpenSearch spec.Valid parameter values are:
        /// - off: Disable SafeSearch (default)
        /// - medium: Enable SafeSearch
        /// - high: Enable a stricter version of SafeSearch
        /// </summary>
        [JsonProperty("safe")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual SafetyLevel? SafetyLevel { get; set; }

        /// <summary>
        /// The identifier of a custom search engine created using the Custom Search Control Panel, if specified in request. 
        /// This is a custom property not defined in the OpenSearch spec.
        /// </summary>
        [JsonProperty("cx")]
        public virtual string SearchEngineId { get; set; }

        /// <summary>
        /// Specifies that results should be sorted according to the specified expression. 
        /// For example, sort by date.
        /// </summary>
        [JsonProperty("sort")]
        [JsonConverter(typeof(SortExpressionJsonConverter))]
        public virtual SortExpression SortExpression { get; set; }

        /// <summary>
        /// Activates or deactivates the automatic filtering of Google search results. 
        /// See Automatic Filtering for more information about Google's search results filters.
        /// https://developers.google.com/custom-search/docs/xml_results#automaticFiltering
        /// The default value for the filter parameter is 1, which indicates that the feature is enabled.Valid values for this parameter are:
        /// - 0: Disabled
        /// - 1: Enabled
        /// Note: By default, Google applies filtering to all search results to improve the quality of those results.
        /// </summary>
        [JsonProperty("filter")]
        [JsonConverter(typeof(StringBooleanConverter))]
        public virtual bool Filter { get; set; }

        /// <summary>
        /// Boosts search results whose country of origin matches the parameter value. 
        /// See Country Codes for a list of valid values. https://developers.google.com/custom-search/docs/xml_results#countryCodes
        /// Specifying a gl parameter value in WebSearch requests should improve the relevance of results.
        /// This is particularly true for international customers and, even more specifically, 
        /// for customers in English-speaking countries other than the United States.
        /// </summary>
        [JsonProperty("gl")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual GeoLocation? GeoLocation { get; set; }

        /// <summary>
        /// Restricts search results to documents originating in a particular country. 
        /// You may use Boolean operators in the cr parameter's value. https://developers.google.com/custom-search/docs/xml_results#booleanOperators
        /// Google WebSearch determines the country of a document by analyzing the following:
        /// The top-level domain(TLD) of the document's URL.
        /// The geographic location of the web server's IP address.
        /// See Country(cr) Parameter Values for a list of valid values for this parameter.
        /// https://developers.google.com/custom-search/docs/xml_results#countryCollections
        /// </summary>
        [JsonProperty("cr")]
        public virtual string CountryRestrict { get; set; }

        /// <summary>
        /// Specifies the Google domain (for example, google.com, google.de, or google.fr) to which the search should be limited.
        /// </summary>
        [JsonProperty("googleHost")]
        public virtual string Googlehost { get; set; }

        /// <summary>
        /// Enables or disables the Simplified and Traditional Chinese Search feature.
        /// Supported values are:
        /// - 0: enabled(default)
        /// - 1: disabled
        /// </summary>
        [JsonProperty("disableCnTwTranslation")]
        [JsonConverter(typeof(StringBooleanConverter))]
        public virtual bool DisableCnTwTranslation { get; set; } = true;

        /// <summary>
        /// Appends the specified query terms to the query, as if they were combined with a logical AND operator.
        /// </summary>
        [JsonProperty("hq")]
        public virtual string AndTerms { get; set; }

        /// <summary>
        /// Specifies the interface language (host language) of your user interface. 
        /// Explicitly setting this parameter improves the performance and the quality of your search results.
        /// See the Interface Languages section of Internationalizing Queries and Results Presentation for more information, 
        /// and Supported Interface Languages for a list of supported languages.
        /// https://developers.google.com/custom-search/docs/xml_results#wsInterfaceLanguages
        /// </summary>
        [JsonProperty("hl")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Language? InterfaceLanguage { get; set; }

        /// <summary>
        /// Specifies all search results should be pages either included or excluded, from a given site.
        /// </summary>
        public virtual SiteSearch SiteSearch => string.IsNullOrEmpty(this.SiteSearchStr) 
            ? null 
            : new SiteSearch { Site = SiteSearchStr, Filter = SiteSearchFilterEnum };

        /// <summary>
        /// Identifies a phrase that all documents in the search results must contain.
        /// </summary>
        [JsonProperty("exactTerms")]
        public virtual string ExactTerms { get; set; }

        /// <summary>
        /// Identifies a word or phrase that should not appear in any documents in the search results.
        /// </summary>
        [JsonProperty("excludeTerms")]
        public virtual string ExcludeTerms { get; set; }

        /// <summary>
        /// Specifies that all results should contain a link to a specific URL.
        /// </summary>
        [JsonProperty("linkSite")]
        public virtual string LinkSite { get; set; }

        /// <summary>
        /// Provides additional search terms to check for in a document, 
        /// where each document in the search results must contain at least one of the additional search terms. 
        /// You can also use the Boolean OR query term for this type of query.
        /// </summary>
        [JsonProperty("orTerms")]
        public virtual string OrTerms { get; set; }

        /// <summary>
        /// Specifies that all search results should be pages that are related to the specified URL. 
        /// The parameter value should be a URL.
        /// </summary>
        [JsonProperty("relatedSite")]
        public virtual string RelatedSite { get; set; }

        /// <summary>
        /// Restricts results to URLs based on date. 
        /// Supported values include:
        /// - d[number]: requests results from the specified number of past days. 
        /// - w[number]: requests results from the specified number of past weeks. 
        /// - m[number]: requests results from the specified number of past months. 
        /// - y[number]: requests results from the specified number of past years.
        /// </summary>
        [JsonProperty("dateRestrict")]
        [JsonConverter(typeof(DateRestrictJsonConverter))]
        public virtual DateRestrict DateRestrict { get; set; }

        /// <summary>
        /// Specifies the starting value for a search range. 
        /// Use cse:lowRange and cse:highrange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        [JsonProperty("lowRange")]
        public virtual int? LowRange { get; set; }

        /// <summary>
        /// Specifies the ending value for a search range. 
        /// Use cse:lowRange and cse:highrange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>'
        [JsonProperty("highRange")]
        public virtual int? HighRange { get; set; }

        /// <summary>
        /// Restricts results to files of a specified extension.
        /// A list of file types indexable by Google can be found in Search Console Help Center. https://support.google.com/webmasters/answer/35287?hl=en
        /// Additional filetypes may be added in the future. An up-to-date list can always be found in Google's file type FAQ.
        /// </summary>
        [JsonProperty("fileType")]
        [JsonConverter(typeof(StringEnumListConverter<FileType>))]
        public virtual IEnumerable<FileType> FileTypes { get; set; }

        /// <summary>
        /// Rights - Filters based on licensing.
        /// Supported values include: 
        /// - cc_publicdomain 
        /// - cc_attribute
        /// - cc_sharealike
        /// - cc_noncommercial
        /// - cc_nonderived
        /// - and combinations of these.
        /// </summary>
        [JsonProperty("rights")]
        [JsonConverter(typeof(StringEnumListConverter<RightsType>))]
        public virtual IEnumerable<RightsType> Rights { get; set; }

        /// <summary>
        /// Allowed values are web or image. If unspecified, results are limited to webpages.
        /// </summary>
        [JsonProperty("searchType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual SearchType? SearchType { get; set; }

        /// <summary>
        /// Restricts results to images of a specified size. 
        /// </summary>
        [JsonProperty("imgSize")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual ImageSize? ImageSize { get; set; }

        /// <summary>
        /// Restricts results to images of a specified type. 
        /// </summary>
        [JsonProperty("imgType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual ImageType? ImageType { get; set; }

        /// <summary>
        /// Restricts results to images of a specified color type. 
        /// </summary>
        [JsonProperty("imgColorType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual ColorType? ImageColorType { get; set; }

        /// <summary>
        /// Restricts results to images with a specific dominant color.
        /// </summary>
        [JsonProperty("imgDominantColor")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual DominantColorType? ImageDominantColor { get; set; }

        [JsonProperty("siteSearch")]
        private string SiteSearchStr { get; set; }

        [JsonProperty("siteSearchFilter")]
        [JsonConverter(typeof(StringEnumConverter))]
        private SiteSearchFilter SiteSearchFilterEnum { get; set; } = SiteSearchFilter.Include;
    }
}