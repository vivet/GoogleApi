using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.TimeZone.Response;

/// <summary>
/// TimeZone Response.
/// </summary>
public class TimeZoneResponse : BaseResponse
{
    /// <summary>
    /// DstOffset: the offset for daylight-savings time in seconds.
    /// This will be zero if the time zone is not in Daylight Savings Time during the specified timestamp.
    /// </summary>
    [JsonPropertyName("dstOffset")]
    public virtual double OffSet { get; set; }

    /// <summary>
    /// RawOffset: the offset from UTC (in seconds) for the given location.
    /// This does not take into effect daylight savings.
    /// </summary>
    public virtual double RawOffSet { get; set; }

    /// <summary>
    /// TimeZoneId: a string containing the ID of the time zone, such as "America/Los_Angeles" or "Australia/Sydney".
    /// </summary>
    public virtual string TimeZoneId { get; set; }

    /// <summary>
    /// TimeZoneName: a string containing the long form name of the time zone.
    /// This field will be localized if the language parameter is set. eg. "Pacific Daylight Time" or "Australian".
    /// </summary>
    public virtual string TimeZoneName { get; set; }
}
