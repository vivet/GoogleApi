using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.Search.NearBy.Request;

namespace GoogleApi.Entities.PlacesNew.Search.Common;

/// <summary>
/// Parameters to configure the routing calculations to the places in the response,
/// both along a route (where result ranking will be influenced) and for calculating travel times on results.
/// </summary>
public class RoutingParameters
{
    /// <summary>
    /// Optional. An explicit routing origin that overrides the origin defined in the polyline.
    /// By default, the polyline origin is used.
    /// </summary>
    public virtual LatLng Origin { get; set; }

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual PlaceTravelMode TravelMode { get; set; } = PlaceTravelMode.Drive;

    /// <summary>
    /// Route Modifiers (optional).
    /// A set of conditions to satisfy that affect the way routes are calculated.
    /// </summary>
    public virtual RouteModifiers RouteModifiers { get; set; }

    /// <summary>
    /// Specifies the mode of transportation. (optional).
    /// </summary>
    public virtual RoutingPreference? RoutingPreference { get; set; }
}