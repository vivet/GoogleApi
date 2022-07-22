using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Search.Video.Common;
using GoogleApi.Entities.Search.Video.Common.Enums;

namespace GoogleApi.Entities.Search.Video;

/// <summary>
/// Base Video Search Response (abstract).
/// </summary>
public abstract class BaseVideoSearchResponse : BaseResponse
{
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
    /// Page Token.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    public virtual string PageToken { get; set; }

    /// <summary>
    /// Region Code.
    /// </summary>
    [JsonPropertyName("regionCode")]
    public virtual Country Region { get; set; }

    /// <summary>
    /// Page Info.
    /// </summary>
    public virtual PageInfo PageInfo { get; set; }

    /// <summary>
    /// Items.
    /// </summary>
    public virtual IEnumerable<Item> Items { get; set; }
}