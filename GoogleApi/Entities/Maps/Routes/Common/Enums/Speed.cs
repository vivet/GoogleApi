using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Common.Enums;

/// <summary>
/// Speed.
/// The classification of polyline speed based on traffic data.
/// </summary>
public enum Speed
{
    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    [EnumMember(Value = "SPEED_UNSPECIFIED")]
    SpeedUnspecified,

    /// <summary>
    /// Normal speed, no slowdown is detected.
    /// </summary>
    [EnumMember(Value = "NORMAL")]
    Normal,

    /// <summary>
    /// Slowdown detected, but no traffic jam formed.
    /// </summary>
    [EnumMember(Value = "SLOW")]
    Slow,

    /// <summary>
    /// Traffic jam detected.
    /// </summary>
    [EnumMember(Value = "TRAFFIC_JAM")]
    TrafficJam
}