using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Request.Enums;

/// <summary>
/// Route Travel mode.
/// </summary>
public enum RouteTravelMode
{
    /// <summary>
    /// Travel by passenger car..
    /// </summary>
    [EnumMember(Value = "DRIVE")]
    Drive,

    /// <summary>
    /// Requests distance calculation for bicycling via bicycle paths and preferred streets (where available).
    /// </summary>
    [EnumMember(Value = "BICYCLE")]
    Bicycle,

    /// <summary>
    /// Requests distance calculation for walking via pedestrian paths and sidewalks (where available).
    /// </summary>
    [EnumMember(Value = "WALK")]
    Walk,

    /// <summary>
    /// Two-wheeled, motorized vehicle.
    /// For example, motorcycle.
    /// Note that this differs from the BICYCLE travel mode which covers human-powered mode.
    /// </summary>
    [EnumMember(Value = "TWO_WHEELER")]
    TwoWheeler
}