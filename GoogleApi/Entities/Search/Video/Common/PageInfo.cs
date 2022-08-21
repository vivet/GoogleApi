using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Page Info.
/// </summary>
public class PageInfo
{
    /// <summary>
    /// Total Results.
    /// </summary>
    [JsonProperty("totalResults")]
    public virtual int TotalResults { get; set; }

    /// <summary>
    /// Results Per Page.
    /// </summary>
    [JsonProperty("resultsPerPage")]
    public virtual int ResultsPerPage { get; set; }
}