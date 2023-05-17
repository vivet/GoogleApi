using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Directions.Request;

/// <summary>
/// Way Point.
/// </summary>
public class WayPoint
{
    /// <summary>
    /// Location.
    /// </summary>
    public LocationEx Location { get; }

    /// <summary>
    /// IsVia.
    /// The via: prefix is most effective when creating routes in response to the user dragging the waypoints on the map.
    /// Doing so allows the user to see how the final route may look in real-time and
    /// helps ensure that waypoints are placed in locations that are accessible to the Directions API.
    /// Caution: Using the via: prefix to avoid stopovers results in directions that are strict in their interpretation of the waypoint.
    /// This interprestation may result in severe detours on the route or ZERO_RESULTS in the response status code
    /// if the Directions API is unable to create directions through that point.
    /// </summary>
    public bool IsVia { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="location">The <see cref="Location"/>.</param>
    /// <param name="isVia">is prefixed with 'via:'</param>
    public WayPoint(LocationEx location, bool isVia = false)
    {
        this.Location = location;
        this.IsVia = isVia;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return this.IsVia
            ? $"via:{this.Location}"
            : this.Location.ToString();
    }
}