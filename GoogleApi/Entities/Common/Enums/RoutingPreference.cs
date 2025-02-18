using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Routing Preference.
/// </summary>
public enum RoutingPreference
{
    /// <summary>
    /// Computes routes without taking live traffic conditions into consideration.
    /// Suitable when traffic conditions don't matter or are not applicable. Using this value produces the lowest latency.
    /// Be aware for RouteTravelMode DRIVE and TWO_WHEELER choice of route and duration are based on road network and
    /// average time-independent traffic conditions. Results for a given request may vary over time due to changes in the road network,
    /// updated average traffic conditions, and the distributed nature of the service.
    /// Results may also vary between nearly-equivalent routes at any time or frequency.
    /// </summary>
    [EnumMember(Value = "TRAFFIC_UNAWARE")]
    TrafficUnaware,

    /// <summary>
    /// Calculates routes taking live traffic conditions into consideration.
    /// In contrast to TRAFFIC_AWARE_OPTIMAL, some optimizations are applied to significantly reduce latency.
    /// </summary>
    [EnumMember(Value = "TRAFFIC_AWARE")]
    TrafficAware,

    /// <summary>
    /// Calculates the routes taking live traffic conditions into consideration, without applying most performance optimizations.
    /// Using this value produces the highest latency.
    /// </summary>
    [EnumMember(Value = "TRAFFIC_AWARE_OPTIMAL")]
    TrafficAwareOptimal
}