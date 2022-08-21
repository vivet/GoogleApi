using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Thumbnail.
/// </summary>
public class Thumbnail
{
    /// <summary>
    /// Width.
    /// </summary>
    [JsonProperty("width")]
    public virtual int Width { get; set; }

    /// <summary>
    /// Height.
    /// </summary>
    [JsonProperty("height")]
    public virtual int Height { get; set; }

    /// <summary>
    /// Url.
    /// </summary>
    [JsonProperty("url")]
    public virtual string Url { get; set; }
}