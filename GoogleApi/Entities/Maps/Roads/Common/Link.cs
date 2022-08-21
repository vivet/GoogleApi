using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Roads.Common;

/// <summary>
/// Link.
/// </summary>
public class Link
{
    /// <summary>
    /// Description of the link.
    /// </summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>
    /// the url.
    /// </summary>
    [JsonProperty("url")]
    public virtual string Url { get; set; }
}