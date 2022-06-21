using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Item.
/// </summary>
public class Item
{
    /// <summary>
    /// Video Id.
    /// </summary>
    [JsonProperty("id")]
    public virtual Id Id { get; set; }

    /// <summary>
    /// Kind.
    /// </summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>
    /// ETag.
    /// </summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>
    /// Snippet.
    /// </summary>
    [JsonProperty("snippet")]
    public virtual Snippet Snippet { get; set; }
}