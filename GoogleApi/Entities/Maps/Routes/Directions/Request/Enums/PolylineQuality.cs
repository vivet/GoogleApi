using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Request.Enums;

/// <summary>
/// Polyline Quality.
/// A set of values that specify the quality of the polyline.
/// </summary>
public enum PolylineQuality
{
    /// <summary>
    /// Specifies a high-quality polyline - which is composed using more points than OVERVIEW,
    /// at the cost of increased response size.
    /// Use this value when you need more precision.
    /// </summary>
    [EnumMember(Value = "HIGH_QUALITY")]
    HighQuality,

    /// <summary>
    /// Specifies an overview polyline - which is composed using a small number of points.
    /// Use this value when displaying an overview of the route.
    /// Using this option has a lower request latency compared to using the HIGH_QUALITY option.
    /// </summary>
    [EnumMember(Value = "OVERVIEW")]
    Overview
}