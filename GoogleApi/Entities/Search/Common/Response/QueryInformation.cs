using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Request;
using GoogleApi.Entities.Search.Common.Response.Enums;
using Newtonsoft.Json;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Query Information.
    /// </summary>
    [DataContract(Name = "request")]
    public class QueryInformation
    {
        /// <summary>
        /// A description of the query.
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The custom search engine ID used for the request.
        /// </summary>
        [JsonProperty("cx")]
        public virtual string Cx { get; set; }

        /// <summary>
        /// The URL of a linked custom search engine specification used for the request.
        /// </summary>
        [JsonProperty("cref")]
        public virtual string Cref { get; set; }

        /// <summary>
        /// The Language.
        /// </summary>
        [JsonProperty("language")]
        public virtual Language Language { get; set; }

        /// <summary>
        /// The search terms entered by the user.
        /// </summary>
        [JsonProperty("searchTerms")]
        public virtual string SearchTerms { get; set; }

        /// <summary>
        /// The page number of this set of results, where the page length is set by the count property.
        /// </summary>
        [JsonProperty("startPage")]
        public virtual int StartPage { get; set; }

        /// <summary>
        /// Number of search results returned in this set.
        /// </summary>
        [JsonProperty("count")]
        public virtual int Count { get; set; }

        /// <summary>
        /// Estimated number of total search results. May not be accurate.
        /// </summary>
        [JsonProperty("totalResults")]
        public virtual long TotalResults { get; set; }

        /// <summary>
        /// Geolocation of end user.
        /// The geolocation parameter value is a two-letter country code.The gl parameter boosts search results whose country of origin matches the parameter value.
        /// See the Country Codes page for a list of valid values. https://developers.google.com/custom-search/docs/xml_results#countryCodes
        /// Specifying a geolocation parameter value should lead to more relevant results.
        /// This is particularly true for international customers and, even more specifically, for customers in English- speaking countries other than the United States.
        /// </summary>
        [JsonProperty("gl")]
        public virtual Country? GeoLocation { get; set; }

        /// <summary>
        /// Restricts search results to documents originating in a particular country. 
        /// You may use Boolean operators in the cr parameter's value.
        /// Google Search determines the country of a document by analyzing:
        /// the top-level domain(TLD) of the document's URL  the geographic location of the Web server's IP address
        /// See the Country Parameter Values page for a list of valid values for this parameter.
        /// https://developers.google.com/custom-search/docs/xml_results_appendices#countryCollections
        /// </summary>
        [JsonProperty("cr")]
        public virtual Country? CountryRestriction { get; set; }

        /// <summary>
        /// Googlehost - The local Google domain (for example, google.com, google.de, or google.fr) to use to perform the search.
        /// </summary>
        [JsonProperty("googleHost")]
        public virtual string Googlehost { get; set; }

        /// <summary>
        /// SiteSearch - Specifies all search results should be pages from a given site.
        /// </summary>
        [JsonProperty("siteSearch")]
        public virtual string SiteSearch { get; set; }

        /// <summary>
        /// SiteSearchFilter - Controls whether to include or exclude results from the site named in the siteSearch parameter.
        /// Acceptable values are:
        /// - "e": exclude
        /// - "i": include
        /// </summary>
        [JsonProperty("siteSearchFilter")]
        public virtual string SiteSearchFilter { get; set; }

        /// <summary>
        /// ExactTerms - Identifies a phrase that all documents in the search results must contain.
        /// </summary>
        [JsonProperty("exactTerms")]
        public virtual string ExactTerms { get; set; }

        /// <summary>
        /// ExactTerms - Identifies a word or phrase that should not appear in any documents in the search results.
        /// </summary>
        [JsonProperty("excludeTerms")]
        public virtual string ExcludeTerms { get; set; }

        /// <summary>
        /// OrTerms - Provides additional search terms to check for in a document, 
        /// where each document in the search results must contain at least one of the additional search terms.
        /// </summary>
        [JsonProperty("orTerms")]
        public virtual string OrTerms { get; set; }

        /// <summary>
        /// AndTerms - string Appends the specified query terms to the query, as if they were combined with a logical AND operator.
        /// </summary>
        [JsonProperty("hq")]
        public virtual string AndTerms { get; set; }

        /// <summary>
        /// LinkSite - Specifies that all search results should contain a link to a particular URL.
        /// </summary>
        [JsonProperty("linkSite")]
        public virtual string LinkSite { get; set; }

        /// <summary>
        /// RelatedSite - Specifies that all search results should be pages that are related to the specified URL.
        /// </summary>
        [JsonProperty("relatedSite")]
        public virtual string RelatedSite { get; set; }

        /// <summary>
        /// Start - The index of the first result to return.
        /// </summary>
        [JsonProperty("startIndex")]
        public virtual int StartIndex { get; set; }

        /// <summary>
        /// SafetyLevel - Search safety level.
        /// Acceptable values are:
        /// - "off": Disables SafeSearch filtering. (default)
        ///-  "medium": Enables moderate SafeSearch filtering.
        /// - "high": Enables highest level of SafeSearch filtering.
        /// </summary>
        [JsonProperty("safe")]
        public virtual SafetyLevel SafetyLevel { get; set; } = SafetyLevel.Off;

        /// <summary>
        /// Rights - Filters based on licensing.
        /// Supported values include: cc_publicdomain, cc_attribute, cc_sharealike, cc_noncommercial, cc_nonderived, and combinations of these.
        /// </summary>
        [JsonProperty("rights")]
        public virtual IEnumerable<RightsType> Rights { get; set; }

        /// <summary>
        /// FileType - Restricts results to files of a specified extension.
        /// A list of file types indexable by Google can be found in Search Console Help Center. https://support.google.com/webmasters/answer/35287?hl=en
        /// </summary>
        [JsonProperty("fileType")]
        public virtual IEnumerable<FileType> FileTypes { get; set; }

        /// <summary>
        /// Allowed values are web or image. If unspecified, results are limited to webpages.
        /// </summary>
        [JsonProperty("searchType")]
        public virtual SearchType? SearchType { get; set; }

        /// <summary>
        /// LowRange - Specifies the starting value for a search range.
        /// Use lowRange and highRange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        [JsonProperty("lowRange")]
        public virtual string LowRange { get; set; }

        /// <summary>
        /// HighRange - Specifies the ending value for a search range.
        /// Use lowRange and highRange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        [JsonProperty("highRange")]
        public virtual string HighRange { get; set; }

        /// <summary>
        /// Type - Returns images of a type. 
        /// </summary>
        [JsonProperty("imgType")]
        public virtual ImageType? ImageType { get; set; }

        /// <summary>
        /// Size - Returns images of a specified size.
        /// </summary>
        [JsonProperty("imgSize")]
        public virtual ImageSize? ImageSize { get; set; }

        /// <summary>
        /// ColorType - Returns black and white, grayscale, or color images: mono, gray, and color.
        /// </summary>
        [JsonProperty("imgColorType")]
        public virtual ColorType? ImageColorType { get; set; }

        /// <summary>
        /// DominantColor - Returns images of a specific dominant color. 
        /// </summary>
        [JsonProperty("imgDominantColor")]
        public virtual DominantColorType? ImageDominantColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("inputEncoding")]
        public virtual string InputEncodingStr { get; set; }

        /// <summary>
        /// The character encoding supported for search request.
        /// </summary>
        public virtual EncodingType InputEncoding => (EncodingType)Enum.Parse(typeof(EncodingType), this.InputEncodingStr);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("outputEncoding")]
        public virtual string OutputEncodingStr { get; set; }

        /// <summary>
        /// The character encoding supported for search results.
        /// </summary>
        public virtual EncodingType OutputEncoding => (EncodingType)Enum.Parse(typeof(EncodingType), this.OutputEncodingStr);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hl")]
        public virtual string InterfaceLanguageStr { get; set; }

        /// <summary>
        /// Language - Sets the user interface language. 
        /// Explicitly setting this parameter improves the performance and the quality of your search results.
        /// See the Interface Languages section of Internationalizing Queries and Results Presentation for more information, 
        /// and Supported Interface Languages for a list of supported languages.
        /// https://developers.google.com/custom-search/docs/xml_results#interfaceLanguages
        /// </summary>
        public virtual Language InterfaceLanguage => (Language)Enum.Parse(typeof(Language), this.InterfaceLanguageStr);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("filter")]
        public virtual string FilterStr { get; set; }
        
        /// <summary>
        /// Filter - Controls turning on or off the duplicate content filter.
        /// See Automatic Filtering for more information about Google's search results filters. 
        /// Note that host crowding filtering applies only to multi-site searches.
        /// By default, Google applies filtering to all search results to improve the quality of those results.
        /// https://developers.google.com/custom-search/docs/xml_results#automaticFiltering.
        /// </summary>
        public virtual bool Filter => bool.Parse(this.FilterStr);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("disableCnTwTranslation")]
        public virtual string DisableCnTwTranslationStr { get; set; }

        /// <summary>
        /// Enables or disables the Simplified and Traditional Chinese Search feature.
        /// The default value for this parameter is true, meaning that the feature is enabled.
        /// </summary>
        public virtual bool DisableCnTwTranslation => bool.Parse(this.DisableCnTwTranslationStr);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sort")]
        public virtual string SortStr { get; set; }

        /// <summary>
        /// Sort - The sort expression to apply to the results.
        /// </summary>
        public virtual SortExpression SortExpression => new SortExpression().FromString(this.SortStr);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dateRestrict")]
        public virtual string DateRestrictStr { get; set; }

        /// <summary>
        /// DateRestrict - Restricts results to URLs based on date.
        /// </summary>
        public virtual DateRestrictType? DateRestrictType
        {
            get
            {
                var indexOf = this.DateRestrictStr.IndexOf('[');
                return indexOf == -1 ? (DateRestrictType?)null : (DateRestrictType)Enum.Parse(typeof(DateRestrictType), this.DateRestrictStr.Substring(0, indexOf - 1));
            }
        }

        /// <summary>
        /// DateRestrictNumber - Requests results from the specified number of past days, weeks, months or years.
        /// </summary>
        public virtual int? DateRestrictNumber
        {
            get
            {
                var startIndex = this.DateRestrictStr.IndexOf('[');
                var endIndex = this.DateRestrictStr.IndexOf(']');

                return startIndex == -1 || endIndex == -1 ? (int?)null : int.Parse(this.DateRestrictStr.Substring(startIndex, endIndex - startIndex));
            }
        }
    }
}