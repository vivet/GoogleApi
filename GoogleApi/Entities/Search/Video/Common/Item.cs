using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Item.
/// </summary>
public class Item
{
    /// <summary>
    /// Video Id.
    /// </summary>
    public virtual Id Id { get; set; }

    /// <summary>
    /// Kind.
    /// </summary>
    public virtual string Kind { get; set; }

    /// <summary>
    /// ETag.
    /// </summary>
    [JsonPropertyName("etag")]
    public virtual string ETag { get; set; }

    /// <summary>
    /// Snippet.
    /// </summary>
    public virtual Snippet Snippet { get; set; }
}