namespace GoogleApi.Entities.Search.Video.Videos.Request.Enums;

/// <summary>
/// Video Caption Type.
/// </summary>
public enum VideoCaptionType
{
    /// <summary>
    /// Any.
    /// Do not filter results based on caption availability.
    /// This is the default value.
    /// </summary>
    Any,

    /// <summary>
    /// Closed Caption.
    /// Only include videos that have captions.
    /// </summary>
    ClosedCaption,

    /// <summary>
    /// None.
    /// Only include videos that do not have captions.
    /// </summary>
    None
}