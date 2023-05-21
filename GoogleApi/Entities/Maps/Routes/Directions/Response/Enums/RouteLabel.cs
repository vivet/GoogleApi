using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

/// <summary>
/// Route Label.
/// Labels for the Route that are useful to identify specific properties of the route to compare against others.
/// </summary>
public enum RouteLabel
{
    /// <summary>
    /// Default - not used.
    /// </summary>
    [EnumMember(Value = "ROUTE_LABEL_UNSPECIFIED")]
    RouteLabelUnspecified,

    /// <summary>
    /// The default "best" route returned for the route computation.
    /// </summary>
    [EnumMember(Value = "DEFAULT_ROUTE")]
    DefaultRoute,

    /// <summary>
    /// An alternative to the default "best" route.
    /// Routes like this will be returned when computeAlternativeRoutes is specified.
    /// </summary>
    [EnumMember(Value = "DEFAULT_ROUTE_ALTERNATE")]
    DefaultRouteAlternate,

    /// <summary>
    /// Fuel efficient route.
    /// Routes labeled with this value are determined to be optimized for Eco parameters such as fuel consumption.
    /// </summary>
    [EnumMember(Value = "FUEL_EFFICIENT")]
    FuelEfficient
}