using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Structured information for special days that fall within the period that the returned opening hours cover.
/// Special days are days that could impact the business hours of a place, e.g. Christmas day..
/// </summary>
public class SpecialDay
{
    /// <summary>
    /// The date of this special day.
    /// </summary>
    public virtual Date Date { get; set; }
}