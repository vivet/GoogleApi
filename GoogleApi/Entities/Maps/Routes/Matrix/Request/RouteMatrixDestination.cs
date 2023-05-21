using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Request;

/// <summary>
/// Route Matrix Destination.
/// A single destination for ComputeRouteMatrixRequest.
/// </summary>
public class RouteMatrixDestination
{
    /// <summary>
    /// Destination Waypoint (required).
    /// </summary>
    public virtual RouteWayPoint Waypoint { get; set; }
}