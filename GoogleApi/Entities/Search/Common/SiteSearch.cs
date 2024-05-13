using System.Text.Json.Serialization;
using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Site Search.
/// </summary>
public class SiteSearch
{
    /// <summary>
    /// Site - Specifies all search results should be pages from a given site.
    /// </summary>
    [JsonPropertyName("siteSearch")]
    public virtual string Site { get; set; }

    /// <summary>
    /// Filter - Controls whether to include or exclude results from the site named in the siteSearch parameter.
    /// Acceptable values are:
    /// - "e": exclude
    /// - "i": include
    /// </summary>
    public virtual SiteSearchFilter Filter { get; set; } = SiteSearchFilter.Include;
}