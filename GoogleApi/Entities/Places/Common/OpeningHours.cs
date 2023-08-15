using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Places.Common.Enums;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Opening Hours.
/// </summary>
public class OpeningHours
{
    /// <summary>
    /// OpenNow is a boolean value indicating if the Place is open at the current time.
    /// </summary>
    [JsonPropertyName("open_now")]
    public virtual bool OpenNow { get; set; } = false;

    /// <summary>
    /// periods[] is an array of opening periods covering seven days, starting from Sunday, in chronological order.
    /// </summary>
    public virtual IEnumerable<Period> Periods { get; set; }

    /// <summary>
    /// WeekdayTexts is an array of seven strings representing the formatted opening hours for each day of the week.
    /// If a language parameter was specified in the Place Details request, the Places Service will format and localize the opening hours appropriately for that language.
    /// The ordering of the elements in this array depends on the language parameter. Some languages start the week on Monday while others start on Sunday.
    /// </summary>
    [JsonPropertyName("weekday_text")]
    public virtual IEnumerable<string> WeekdayTexts { get; set; }

    /// <summary>
    /// An array of opening periods covering seven days, starting from Sunday, in chronological order.
    /// See PlaceOpeningHoursPeriod for more information.
    /// </summary>
    [JsonPropertyName("special_days")]
    public virtual IEnumerable<SpecialDay> SpecialDays { get; set; }

    /// <summary>
    /// A type string used to identify the type of secondary hours.
    /// </summary>
    public virtual OpeningHoursType? Type { get; set; }
}