using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Details.Response;

/// <summary>
/// DayTime.
/// </summary>
public class DayTime
{
    /// <summary>
    /// Day a number from 0–6, corresponding to the days of the week, starting on Sunday.
    /// For example, 2 means Tuesday.
    /// </summary>
    [JsonProperty("day")]
    public virtual int Day { get; set; }

    /// <summary>
    /// Time may contain a time of day in 24-hour hhmm format (values are in the range 0000–2359).
    /// The time will be reported in the Place’s timezone
    /// </summary>
    [JsonProperty("time")]
    public virtual string Time { get; set; }
}