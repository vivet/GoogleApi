namespace GoogleApi.Entities.Search.Video.Videos.Request.Enums;

/// <summary>
/// Video Type.
/// </summary>
public enum VideoType
{
    /// <summary>
    /// Any.
    /// Return all videos.
    /// This is the default value.
    /// </summary>
    Any,

    /// <summary>
    /// Episode.
    /// Only retrieve episodes of shows.
    /// </summary>
    Episode,

    /// <summary>
    /// Episode.
    /// Only retrieve movies.
    /// </summary>
    Movie
}