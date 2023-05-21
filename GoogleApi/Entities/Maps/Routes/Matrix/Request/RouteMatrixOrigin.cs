using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Request;

/// <summary>
/// Route Matrix Origin.
/// A single origin for ComputeRouteMatrixRequest.
/// </summary>
public class RouteMatrixOrigin
{
    /// <summary>
    /// Origin Waypoint (required).
    /// </summary>
    public virtual RouteWayPoint Waypoint { get; set; }

    /// <summary>
    /// Route Modifiers (optional).
    /// A set of conditions to satisfy that affect the way routes are calculated.
    /// </summary>
    public virtual RouteModifiers RouteModifiers { get; set; }
}