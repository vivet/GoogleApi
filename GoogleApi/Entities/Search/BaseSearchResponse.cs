using System.Collections.Generic;
using GoogleApi.Entities.Search.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search
{
    /// <summary>
    /// Base abstract class for Search responses.
    /// </summary>
    public class BaseSearchResponse : BaseResponse
    {
        /// <summary>
        /// Unique identifier for the type of current object. For this API, it is customsearch#search.
        /// </summary>
        [JsonProperty("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// The OpenSearch URL element that defines the template for this API.
        /// </summary>
        [JsonProperty("url")]
        public virtual Url Url { get; set; }

        /// <summary>
        /// Metadata about the particular search engine that was used for performing the search query.
        /// </summary>
        [JsonProperty("context")]
        public virtual Context Context { get; set; }

        /// <summary>
        /// Encapsulates a corrected query.
        /// </summary>
        [JsonProperty("spelling")]
        public virtual Spelling Spelling { get; set; }

        /// <summary>
        /// Encapsulates all information about the search.
        /// </summary>
        [JsonProperty("searchInformation")]
        public virtual SearchInfo Search { get; set; }

        /// <summary>
        /// The current set of search results.
        /// </summary>
        [JsonProperty("items")]
        public virtual IEnumerable<Item> Items { get; set; }

        /// <summary>
        /// The set of promotions. Present only if the custom search engine's configuration files define any promotions for the given query.
        /// https://developers.google.com/custom-search/docs/promotions.
        /// </summary>
        [JsonProperty("promotions")]
        public virtual IEnumerable<Promotion> Promotions { get; set; }

        /// <summary>
        /// Contains one or more sets of query metadata, keyed by role name. 
        /// The possible role names are defined by the OpenSearch query roles and by two custom roles: nextPage and previousPage.
        /// http://www.opensearch.org/Specifications/OpenSearch/1.1#OpenSearch_Query_element
        /// </summary>
        [JsonProperty("queries")]
        public virtual IDictionary<string, IEnumerable<QueryInfo>> Queries { get; set; }
    }
}