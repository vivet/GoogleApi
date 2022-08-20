using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Encapsulates all information about the search.
/// </summary>
public class SearchInfo
{
    /// <summary>
    /// The time taken for the server to return search results.
    /// </summary>
    public virtual double SearchTime { get; set; }

    /// <summary>
    /// The time taken for the server to return search results, formatted according to locale style.
    /// </summary>
    [JsonPropertyName("formattedSearchTime")]
    public virtual string SearchTimeFormatted { get; set; }

    /// <summary>
    /// The total number of search results returned by the query.
    /// </summary>
    public virtual long TotalResults { get; set; }

    /// <summary>
    /// The total number of search results, formatted according to locale style.
    /// </summary>
    [JsonPropertyName("formattedTotalResults")]
    public virtual string TotalResultsFormatted { get; set; }
}