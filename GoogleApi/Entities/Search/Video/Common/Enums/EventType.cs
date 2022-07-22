namespace GoogleApi.Entities.Search.Video.Common.Enums;

/// <summary>
/// Event Type.
/// </summary>

public enum EventType
{
    /// <summary>
    /// Completed.
    /// Only include completed broadcasts.
    /// </summary>
    Completed,

    /// <summary>
    /// Live.
    /// Only include active broadcasts.
    /// </summary>
    Live,

    /// <summary>
    /// Upcoming.
    /// Only include upcoming broadcasts.
    /// </summary>
    Upcoming
}