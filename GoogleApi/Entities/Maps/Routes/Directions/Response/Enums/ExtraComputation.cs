using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

/// <summary>
/// Extra Computation.
/// Extra computations to perform while completing the request.
/// </summary>
public enum ExtraComputation
{
    /// <summary>
    /// Toll information for the route(s).
    /// </summary>
    [EnumMember(Value = "TOLLS")]
    Tolls,

    /// <summary>
    /// Estimated fuel consumption for the route(s).
    /// </summary>
    [EnumMember(Value = "FUEL_CONSUMPTION")]
    FuelConsumption,

    /// <summary>
    /// Traffic aware polylines for the route(s).
    /// </summary>
    [EnumMember(Value = "TRAFFIC_ON_POLYLINE")]
    TrafficOnPolyline
}