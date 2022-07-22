using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Directions Response.
/// </summary>
public class DirectionsResponse : BaseResponse
{
    /// <summary>
    /// "routes" contains an array of routes from the origin to the destination. See Routes below.
    /// </summary>
    public virtual IEnumerable<Route> Routes { get; set; }

    /// <summary>
    /// WayPoints.
    /// Details about the geocoding of every waypoint, as well as origin and destination, can be found in the (JSON) geocoded_waypoints array.
    /// These can be used to infer why the service would return unexpected or no routes. Elements in the geocoded_waypoints array correspond,
    /// by their zero-based position, to the origin, the waypoints in the order they are specified, and the destination.Each element includes the following
    /// details about the geocoding operation for the corresponding waypoint
    /// </summary>
    [JsonPropertyName("geocoded_waypoints")]
    public virtual IEnumerable<WayPoint> WayPoints { get; set; }
}