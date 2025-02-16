using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Search.NearBy.Request;

/// <summary>
/// Place Travel mode.
/// </summary>
public enum PlaceTravelMode
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
    /// Be aware that this differs from the BICYCLE travel mode which covers human-powered mode.
    /// </summary>
    [EnumMember(Value = "TWO_WHEELER")]
    TwoWheeler
}