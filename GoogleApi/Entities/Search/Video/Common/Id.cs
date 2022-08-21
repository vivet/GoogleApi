using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Id.
/// </summary>
public class Id
{
    /// <summary>
    /// Kind.
    /// </summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>
    /// Video Id.
    /// </summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }
}