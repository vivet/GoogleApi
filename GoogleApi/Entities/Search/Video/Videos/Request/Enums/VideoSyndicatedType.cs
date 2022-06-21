namespace GoogleApi.Entities.Search.Video.Videos.Request.Enums;

/// <summary>
/// Video Syndicated Type.
/// </summary>
public enum VideoSyndicatedType
{
    /// <summary>
    /// Any.
    /// Return all videos, embeddable or not.
    /// This is the default value.
    /// </summary>
    Any,

    /// <summary>
    /// True.
    /// Only retrieve embeddable videos.
    /// </summary>
    True
}