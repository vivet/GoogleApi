using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Thumbnails.
/// </summary>
public class Thumbnails
{
    /// <summary>
    /// Default.
    /// </summary>
    [JsonProperty("default")]
    public virtual Thumbnail Default { get; set; }

    /// <summary>
    /// Medium.
    /// </summary>
    [JsonProperty("medium")]
    public virtual Thumbnail Medium { get; set; }

    /// <summary>
    /// High.
    /// </summary>
    [JsonProperty("high")]
    public virtual Thumbnail High { get; set; }
}