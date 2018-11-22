using System.Collections.Generic;
using GoogleApi.Entities.Search.Common.Enums;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Define properties of your search, like the search expression, number of results, language etc.
    /// </summary>
    public class SearchOptions
    {
        /// <summary>
        /// Enables or disables the Simplified and Traditional Chinese Search feature.
        /// The default value for this parameter is true, meaning that the feature is enabled.
        /// </summary>
        public virtual bool DisableCnTwTranslation { get; set; } = true;

        /// <summary>
        /// Restricts search results to documents originating in a particular country. 
        /// You may use Boolean operators in the cr parameter's value.
        /// Google Search determines the country of a document by analyzing:
        /// the top-level domain(TLD) of the document's URL  the geographic location of the Web server's IP address
        /// See the Country Parameter Values page for a list of valid values for this parameter.
        /// https://developers.google.com/custom-search/docs/xml_results_appendices#countryCollections
        /// </summary>
        public virtual CountryRestrict CountryRestrict { get; set; }

        /// <summary>
        /// Restricts results to URLs based on date. 
        /// Supported values include:d[number]: requests results from the specified number of past days. w[number]: requests results from the specified number 
        /// of past weeks. m[number]: requests results from the specified number of past months. y[number]: requests results from the specified number of past years.
        /// </summary>
        public virtual DateRestrict DateRestrict { get; set; }

        /// <summary>
        /// ExactTerms - Identifies a phrase that all documents in the search results must contain.
        /// </summary>
        public virtual string ExactTerms { get; set; }

        /// <summary>
        /// ExcludeTerms - Identifies a word or phrase that should not appear in any documents in the search results.
        /// </summary>
        public virtual string ExcludeTerms { get; set; }
   
        /// <summary>
        /// FileType - Restricts results to files of a specified extension.
        /// A list of file types indexable by Google can be found in Search Console Help Center. https://support.google.com/webmasters/answer/35287?hl=en
        /// </summary>
        public virtual IEnumerable<FileType> FileTypes { get; set; } = new List<FileType>();

        /// <summary>
        /// Filter - Controls turning on or off the duplicate content filter.
        /// See Automatic Filtering for more information about Google's search results filters. 
        /// Note that host crowding filtering applies only to multi-site searches.
        /// By default, Google applies filtering to all search results to improve the quality of those results.
        /// https://developers.google.com/custom-search/docs/xml_results#automaticFiltering.
        /// </summary>
        public virtual bool Filter { get; set; } = true;

        /// <summary>
        /// Geolocation of end user.
        /// The geolocation parameter value is a two-letter country code.The gl parameter boosts search results whose country of origin matches the parameter value.
        /// See the Country Codes page for a list of valid values. https://developers.google.com/custom-search/docs/xml_results#countryCodes
        /// Specifying a geolocation parameter value should lead to more relevant results.
        /// This is particularly true for international customers and, even more specifically, for customers in English- speaking countries other than the United States.
        /// </summary>
        public virtual GeoLocation? GeoLocation { get; set; }

        /// <summary>
        /// Googlehost - The local Google domain (for example, google.com, google.de, or google.fr) to use to perform the search.
        /// </summary>
        public virtual string Googlehost { get; set; }

        /// <summary>
        /// HighRange - Specifies the ending value for a search range.
        /// Use lowRange and highRange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        public virtual int? HighRange { get; set; }

        /// <summary>
        /// Language - Sets the user interface language. 
        /// Explicitly setting this parameter improves the performance and the quality of your search results.
        /// See the Interface Languages section of Internationalizing Queries and Results Presentation for more information, 
        /// and Supported Interface Languages for a list of supported languages.
        /// https://developers.google.com/custom-search/docs/xml_results#interfaceLanguages
        /// </summary>
        public virtual Language InterfaceLanguage { get; set; } = Language.English;

        /// <summary>
        /// AndTerms - string Appends the specified query terms to the query, as if they were combined with a logical AND operator.
        /// </summary>
        public virtual string AndTerms { get; set; }
        
        /// <summary>
        /// LinkSite - Specifies that all search results should contain a link to a particular URL.
        /// </summary>
        public virtual string LinkSite { get; set; }

        /// <summary>
        /// LowRange - Specifies the starting value for a search range.
        /// Use lowRange and highRange to append an inclusive search range of lowRange...highRange to the query.
        /// </summary>
        public virtual int? LowRange { get; set; }

        /// <summary>
        /// Number of search results to return.
        /// Valid values are integers between 1 and 10, inclusive.
        /// </summary>
        public virtual int? Number { get; set; } = 10;

        /// <summary>
        /// OrTerms - Provides additional search terms to check for in a document, 
        /// where each document in the search results must contain at least one of the additional search terms.
        /// </summary>
        public virtual string OrTerms { get; set; }

        /// <summary>
        /// RelatedSite - Specifies that all search results should be pages that are related to the specified URL.
        /// </summary>
        public virtual string RelatedSite { get; set; }

        /// <summary>
        /// Rights - Filters based on licensing.
        /// Supported values include: cc_publicdomain, cc_attribute, cc_sharealike, cc_noncommercial, cc_nonderived, and combinations of these.
        /// </summary>
        public virtual IEnumerable<RightsType> Rights { get; set; } = new List<RightsType>();

        /// <summary>
        /// SafetyLevel - Search safety level.
        /// Acceptable values are:
        /// - "off": Disables SafeSearch filtering. (default)
        ///-  "medium": Enables moderate SafeSearch filtering.
        /// - "high": Enables highest level of SafeSearch filtering.
        /// </summary>
        public virtual SafetyLevel SafetyLevel { get; set; } = SafetyLevel.Off;

        /// <summary>
        /// SiteSearch - Specifies all search results should be pages either included or excluded, from a given site.
        /// </summary>
        public virtual SiteSearch SiteSearch { get; set; }

        /// <summary>
        /// The sort expression to apply to the results.
        /// </summary>
        public virtual SortExpression SortExpression { get; set; }

        /// <summary>
        /// Start - The index of the first result to return.
        /// </summary>
        public virtual int StartIndex { get; set; } = 1;
    }
}