namespace GoogleApi.Entities.Maps.Routes.Request;

/// <summary>
/// WayPoint.
/// </summary>
public class WayPoint
{
    /// <summary>
    /// Location.
    /// </summary>
    public CoordianteHeading Location { get; }

    /// <summary>
    /// IsVia.
    /// The via: prefix is most effective when creating routes in response to the user dragging the waypoints on the map.
    /// Doing so allows the user to see how the final route may look in real-time and
    /// helps ensure that waypoints are placed in locations that are accessible to the Directions API.
    /// Caution: Using the via: prefix to avoid stopovers results in directions that are strict in their interpretation of the waypoint.
    /// This interprestation may result in severe detours on the route or ZERO_RESULTS in the response status code
    /// if the Directions API is unable to create directions through that point.
    /// </summary>
    public bool Via { get; }

    /// <summary>
    /// Indicates that the waypoint is meant for vehicles to stop at, where the intention is to either pickup or drop-off.
    /// When you set this value, the calculated route won't include non-via waypoints on roads that are unsuitable for pickup and drop-off.
    /// This option works only for DRIVE and TWO_WHEELER travel modes, and when the locationType is Location.
    /// </summary>
    public bool VehicleStopover { get; set; }

    /// <summary>
    /// Use Side Of Road.
    /// Indicates that the location of this waypoint is meant to have a preference for the vehicle to stop at a particular side of road.
    /// When you set this value, the route will pass through the location so that the vehicle can stop at the side of road
    /// that the location is biased towards from the center of the road.
    /// This option works only for 'DRIVE' and 'TWO_WHEELER' RouteTravelMode.
    /// </summary>
    public bool UseSideOfRoad { get; set; } = false;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="location">The <see cref="Location"/>.</param>
    /// <param name="via">is prefixed with 'via:'</param>
    public WayPoint(CoordianteHeading location, bool via = false)
    {
        Location = location;
        Via = via;
    }
}