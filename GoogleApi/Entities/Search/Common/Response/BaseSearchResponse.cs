using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Base abstract class for Search responses.
    /// </summary>
    [DataContract]
    public class BaseSearchResponse : BaseResponse
    {
        /// <summary>
        /// Unique identifier for the type of current object. For this API, it is customsearch#search.
        /// </summary>
        [DataMember(Name = "kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// The OpenSearch URL element that defines the template for this API.
        /// </summary>
        [DataMember(Name = "url")]
        public virtual Url Url { get; set; }

        /// <summary>
        /// Metadata about the particular search engine that was used for performing the search query.
        /// </summary>
        [DataMember(Name = "context")]
        public virtual Context Context { get; set; }

        /// <summary>
        /// Encapsulates a corrected query.
        /// </summary>
        [DataMember(Name = "spelling")]
        public virtual Spelling Spelling { get; set; }

        /// <summary>
        /// Encapsulates all information about the search.
        /// </summary>
        [DataMember(Name = "searchInformation")]
        public virtual SearchInformation SearchInformation { get; set; }

        /// <summary>
        /// The current set of search results.
        /// </summary>
        [DataMember(Name = "items")]
        public virtual IEnumerable<Item> Items { get; set; }

        /// <summary>
        /// The set of promotions. Present only if the custom search engine's configuration files define any promotions for the given query.
        /// https://developers.google.com/custom-search/docs/promotions.
        /// </summary>
        [DataMember(Name = "promotions")]
        public virtual IEnumerable<Promotion> Promotions { get; set; }

        /// <summary>
        /// Contains one or more sets of query metadata, keyed by role name. 
        /// The possible role names are defined by the OpenSearch query roles and by two custom roles: nextPage and previousPage.
        /// http://www.opensearch.org/Specifications/OpenSearch/1.1#OpenSearch_Query_element
        /// </summary>
        [DataMember(Name = "queries")]
        public virtual IDictionary<string, IEnumerable<QueryInformation>> Queries { get; set; }
    }
}