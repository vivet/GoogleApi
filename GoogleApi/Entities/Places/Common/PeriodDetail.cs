using System;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Period Detail.
/// </summary>
public class PeriodDetail
{
    /// <summary>
    /// Day a number from 0–6, corresponding to the days of the week, starting on Sunday.
    /// For example, 2 means Tuesday.
    /// </summary>
    public virtual int Day { get; set; }

    /// <summary>
    /// Time may contain a time of day in 24-hour hhmm format (values are in the range 0000–2359).
    /// The time will be reported in the Place’s timezone
    /// </summary>
    public virtual string Time { get; set; }

    /// <summary>
    /// A date expressed in RFC3339 format in the local timezone for the place,
    /// for example 2010-12-31.
    /// </summary>
    public virtual DateTime? Date { get; set; }

    /// <summary>
    /// True if a given period was truncated due to a seven-day cutoff,
    /// where the period starts before midnight on the date of the request and/or ends at or after midnight on the last day.
    /// This property indicates that the period for open or close can extend past this seven-day cutoff.
    /// </summary>
    public virtual bool Truncated { get; set; }
}