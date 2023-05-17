using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Geocoding Results.
/// Contains GeocodedWaypoints for origin, destination and intermediate waypoints.
/// Only populated for address waypoints.
/// </summary>
public class GeocodingResults
{
    /// <summary>
    /// Origin.
    /// Origin geocoded waypoint.
    /// </summary>
    public virtual GeocodedWaypoint Origin { get; set; }

    /// <summary>
    /// Destination.
    /// Destination geocoded waypoint.
    /// </summary>
    public virtual GeocodedWaypoint Destination { get; set; }

    /// <summary>
    /// Intermediates.
    /// A list of intermediate geocoded waypoints each containing an index field
    /// that corresponds to the zero-based position of the waypoint in the order they were specified in the request.
    /// </summary>
    public virtual IEnumerable<GeocodedWaypoint> Intermediates { get; set; }
}