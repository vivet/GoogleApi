namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Information about the accessibility options a place offers.
/// </summary>
public class AccessibilityOptions
{
    /// <summary>
    /// Place offers wheelchair accessible parking.
    /// </summary>
    public virtual bool WheelchairAccessibleParking { get; set; }

    /// <summary>
    /// Places has wheelchair accessible entrance.
    /// </summary>
    public virtual bool WheelchairAccessibleEntrance { get; set; }

    /// <summary>
    /// Place has wheelchair accessible restroom.
    /// </summary>
    public virtual bool WheelchairAccessibleRestroom { get; set; }

    /// <summary>
    /// Place has wheelchair accessible seating.
    /// </summary>
    public virtual bool WheelchairAccessibleSeating { get; set; }
}