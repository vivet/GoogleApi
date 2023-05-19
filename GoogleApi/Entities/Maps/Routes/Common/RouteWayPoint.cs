namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Route WayPoint.
/// </summary>
public class RouteWayPoint
{
    /// <summary>
    /// Location.
    /// A point specified using geographic coordinates, including an optional heading.
    /// Specifiy either <see cref="Location"/>, <see cref="Address"/> or <see cref="PlaceId"/>
    /// </summary>
    public virtual RouteLocation Location { get; set; }

    /// <summary>
    /// Human readable address or a plus code. See https://plus.codes for details.
    /// Specifiy either <see cref="Location"/>, <see cref="Address"/> or <see cref="PlaceId"/>
    /// </summary>
    public virtual string Address { get; set; }

    /// <summary>
    /// The POI Place ID associated with the waypoint.
    /// Specifiy either <see cref="Location"/>, <see cref="Address"/> or <see cref="PlaceId"/>
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// IsVia.
    /// The via: prefix is most effective when creating routes in response to the user dragging the waypoints on the map.
    /// Doing so allows the user to see how the final route may look in real-time and
    /// helps ensure that waypoints are placed in locations that are accessible to the Directions API.
    /// Caution: Using the via: prefix to avoid stopovers results in directions that are strict in their interpretation of the waypoint.
    /// This interprestation may result in severe detours on the route or ZERO_RESULTS in the response status code
    /// if the Directions API is unable to create directions through that point.
    /// </summary>
    public virtual bool Via { get; set; }

    /// <summary>
    /// Indicates that the waypoint is meant for vehicles to stop at, where the intention is to either pickup or drop-off.
    /// When you set this value, the calculated route won't include non-via waypoints on roads that are unsuitable for pickup and drop-off.
    /// This option works only for DRIVE and TWO_WHEELER travel modes, and when the locationType is Location.
    /// </summary>
    public virtual bool VehicleStopover { get; set; }

    /// <summary>
    /// Side Of Road.
    /// Indicates that the location of this waypoint is meant to have a preference for the vehicle to stop at a particular side of road.
    /// When you set this value, the route will pass through the location so that the vehicle can stop at the side of road
    /// that the location is biased towards from the center of the road.
    /// This option works only for 'DRIVE' and 'TWO_WHEELER' RouteTravelMode.
    /// </summary>
    public virtual bool SideOfRoad { get; set; } = false;
}