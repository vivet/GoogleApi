using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.PlacesNew.Common.Enums;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Opening Hours.
/// </summary>
public class OpeningHours
{
    /// <summary>
    /// The periods that this place is open during the week. The periods are in chronological order, starting with Sunday in the place-local timezone.
    /// An empty (but not absent) value indicates a place that is never open, e.g. because it is closed temporarily for renovations.
    /// </summary>
    public virtual IEnumerable<Period> Periods { get; set; }

    /// <summary>
    /// Localized strings describing the opening hours of this place, one string for each day of the week.
    /// Will be empty if the hours are unknown or could not be converted to localized text. Example: "Sun: 18:00–06:00"
    /// </summary>
    public virtual IEnumerable<string> WeekdayDescriptions { get; set; }

    /// <summary>
    /// A type string used to identify the type of secondary hours.
    /// </summary>
    public virtual OpeningHoursType SecondaryHoursType { get; set; }

    /// <summary>
    ///Structured information for special days that fall within the period that the returned opening hours cover.
    /// Special days are days that could impact the business hours of a place, e.g. Christmas day.
    /// Set for currentOpeningHours and currentSecondaryOpeningHours if there are exceptional hours.
    /// </summary>
    public virtual IEnumerable<SpecialDay> SpecialDays { get; set; }

    /// <summary>
    /// The next time the current opening hours period starts up to 7 days in the future.
    /// This field is only populated if the opening hours period is not active at the time of serving the request.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    [JsonConverter(typeof(EpochSecondsToDateTimeJsonConverter))]
    public virtual DateTime? NextOpenTime { get; set; }

    /// <summary>
    /// The next time the current opening hours period ends up to 7 days in the future.
    /// This field is only populated if the opening hours period is active at the time of serving the request.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    [JsonConverter(typeof(EpochSecondsToDateTimeJsonConverter))]
    public virtual DateTime? NextCloseTime { get; set; }

    /// <summary>
    /// Whether the opening hours period is currently active. For regular opening hours and current opening hours, this field means whether the place is open.
    /// For secondary opening hours and current secondary opening hours, this field means whether the secondary hours of this place is active.
    /// </summary>
    public virtual bool OpenNow { get; set; } = false;
}