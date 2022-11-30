using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Search.Common;

namespace GoogleApi.Entities.Search;

/// <summary>
/// Base abstract class for Search responses.
/// </summary>
public class BaseSearchResponse : BaseResponse
{
    /// <summary>
    /// Unique identifier for the type of current object. For this API, it is customsearch#search.
    /// </summary>
    public virtual string Kind { get; set; }

    /// <summary>
    /// The OpenSearch URL element that defines the template for this API.
    /// </summary>
    public virtual Url Url { get; set; }

    /// <summary>
    /// Metadata about the particular search engine that was used for performing the search query.
    /// </summary>
    public virtual Context Context { get; set; }

    /// <summary>
    /// Encapsulates a corrected query.
    /// </summary>
    public virtual Spelling Spelling { get; set; }

    /// <summary>
    /// Encapsulates all information about the search.
    /// </summary>
    [JsonPropertyName("searchInformation")]
    public virtual SearchInfo Search { get; set; }

    /// <summary>
    /// The current set of search results.
    /// </summary>
    public virtual IEnumerable<Item> Items { get; set; }

    /// <summary>
    /// The set of promotions. Present only if the custom search engine's configuration files define any promotions for the given query.
    /// https://developers.google.com/custom-search/docs/promotions.
    /// </summary>
    public virtual IEnumerable<Promotion> Promotions { get; set; }

    /// <summary>
    /// Contains <see cref="QueryInfo"/> about the executed request.
    /// </summary>
    public virtual QueryInfo Query => this.Queries?.Where(x => x.Key == "request").Select(x => x.Value.FirstOrDefault()).FirstOrDefault();

    /// <summary>
    /// Contains <see cref="QueryInfo"/> about the next page of the executed request.
    /// </summary>
    public virtual QueryInfo NextPage => this.Queries?.Where(x => x.Key == "nextPage").Select(x => x.Value.FirstOrDefault()).FirstOrDefault();

    /// <summary>
    /// Contains <see cref="QueryInfo"/> about the previous page of the executed request.
    /// </summary>
    public virtual QueryInfo PreviousPage => this.Queries?.Where(x => x.Key == "previousPage").Select(x => x.Value.FirstOrDefault()).FirstOrDefault();

    /// <summary>
    /// Contains one or more sets of query metadata, keyed by role name.
    /// The possible role names are defined by the OpenSearch query roles and by two custom roles: nextPage and previousPage.
    /// http://www.opensearch.org/Specifications/OpenSearch/1.1#OpenSearch_Query_element
    /// </summary>
    public virtual IDictionary<string, IEnumerable<QueryInfo>> Queries { get; set; }
}