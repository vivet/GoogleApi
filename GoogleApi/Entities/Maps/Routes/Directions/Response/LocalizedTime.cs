using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Localized description of time.
/// </summary>
public class LocalizedTime
{
    /// <summary>
    /// The time specified as a string in a given time zone.
    /// </summary>
    public virtual LocalizedText Time { get; set; }

    /// <summary>
    /// Contains the time zone.
    /// The value is the name of the time zone as defined in the IANA Time Zone Database, e.g. "America/New_York".
    /// </summary>
    public virtual string TimeZone { get; set; }
}