using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Common.Enums;

/// <summary>
/// Fallback Routing Mode.
/// Actual routing mode used for returned fallback response.
/// </summary>
public enum FallbackRoutingMode
{
    /// <summary>
    /// Not used.
    /// </summary>
    [EnumMember(Value = "FALLBACK_ROUTING_MODE_UNSPECIFIED")]
    FallbackRoutingModeUnspecified,

    /// <summary>
    /// Indicates the TRAFFIC_UNAWARE google.maps.routing.v2.RoutingPreference was used to compute the response.
    /// </summary>
    [EnumMember(Value = "FALLBACK_TRAFFIC_UNAWARE")]
    FallbackTrafficUnaware,

    /// <summary>
    /// Indicates the TRAFFIC_AWARE RoutingPreference was used to compute the response.
    /// </summary>
    [EnumMember(Value = "FALLBACK_TRAFFIC_AWARE")]
    FallbackTrafficAware
}