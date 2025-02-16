using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Point.
/// </summary>
public class Point
{
    /// <summary>
    /// Date in the local timezone for the place.
    /// </summary>
    public virtual Date Date { get; set; }

    /// <summary>
    /// Whether or not this endpoint was truncated. Truncation occurs when the real hours are outside the times we are willing to return hours between,
    /// so we truncate the hours back to these boundaries.
    /// This ensures that at most 24 * 7 hours from midnight of the day of the request are returned.
    /// </summary>
    public virtual bool Truncated { get; set; }

    /// <summary>
    /// A day of the week, as an integer in the range 0-6. 0 is Sunday, 1 is Monday, etc.
    /// </summary>
    public virtual int Day { get; set; }

    /// <summary>
    /// The hour in 24 hour format. Ranges from 0 to 23.
    /// </summary>
    public virtual int Hour { get; set; }

    /// <summary>
    /// The minute. Ranges from 0 to 59.
    /// </summary>
    public virtual int Minute { get; set; }
}