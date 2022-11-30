using System;

namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
///
/// </summary>
public class Snippet
{
    /// <summary>
    /// Title.
    /// </summary>
    public virtual string Title { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    public virtual string Description { get; set; }

    /// <summary>
    /// Channel Id.
    /// </summary>
    public virtual string ChannelId { get; set; }

    /// <summary>
    /// Channel Title.
    /// </summary>
    public virtual string ChannelTitle { get; set; }

    /// <summary>
    /// Live Broadcast Content.
    /// </summary>
    public virtual string LiveBroadcastContent { get; set; }

    /// <summary>
    /// Category Id.
    /// </summary>
    public virtual int CategoryId { get; set; }

    /// <summary>
    /// Published At.
    /// </summary>
    public virtual DateTimeOffset PublishedAt { get; set; }

    /// <summary>
    /// Thumbnails.
    /// </summary>
    public virtual Thumbnails Thumbnails { get; set; }
}