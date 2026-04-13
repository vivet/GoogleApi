namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Represents a time zone from the IANA Time Zone Database.
/// https://www.iana.org/time-zones
/// </summary>
public class TimeZone
{
    /// <summary>
    /// IANA Time Zone Database time zone. For example "America/New_York".
    /// </summary>
    public virtual string Id { get; set; }

    /// <summary>
    /// Optional. IANA Time Zone Database version number. For example "2019a".
    /// </summary>
    public virtual string Version { get; set; }
}