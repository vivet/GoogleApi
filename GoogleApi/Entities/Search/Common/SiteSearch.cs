using GoogleApi.Entities.Search.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Site Search.
/// </summary>
public class SiteSearch
{
    /// <summary>
    /// Site - Specifies all search results should be pages from a given site.
    /// </summary>
    [JsonProperty("siteSearch")]
    public virtual string Site { get; set; }

    /// <summary>
    /// Filter - Controls whether to include or exclude results from the site named in the siteSearch parameter.
    /// Acceptable values are:
    /// - "e": exclude
    /// - "i": include
    /// </summary>
    [JsonProperty("siteSearchFilter")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual SiteSearchFilter Filter { get; set; } = SiteSearchFilter.Include;
}