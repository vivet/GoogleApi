
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Directions.Request
{
    /// <summary>
    /// WayPoint.
    /// </summary>
    public class WayPoint
    {
        /// <summary>
        /// IsVia.
        /// The via: prefix is most effective when creating routes in response to the user dragging the waypoints on the map.
        /// Doing so allows the user to see how the final route may look in real-time and
        /// helps ensure that waypoints are placed in locations that are accessible to the Directions API.
        /// Caution: Using the via: prefix to avoid stopovers results in directions that are strict in their interpretation of the waypoint.
        /// This interprestation may result in severe detours on the route or ZERO_RESULTS in the response status code
        /// if the Directions API is unable to create directions through that point.
        /// </summary>
        public bool IsVia { get; protected set; }

        /// <summary>
        /// String.
        /// The address, location, polyline or place string.
        /// </summary>
        public string String { get; protected set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wayPoint">The way-point.</param>
        /// <param name="isVia">Is prefixed with 'via:'</param>
        public WayPoint(string wayPoint, bool isVia = false)
        {
            this.String = wayPoint;
            this.IsVia = isVia;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="place">The <see cref="Place"/>.</param>
        /// <param name="isVia">is prefixed with 'via:'</param>
        public WayPoint(Place place, bool isVia = false)
            : this($"place_id:{place?.Id}", isVia)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location">The <see cref="Location"/>.</param>
        /// <param name="isVia">is prefixed with 'via:'</param>
        public WayPoint(Location location, bool isVia = false)
            : this(location.ToString(), isVia)
        {
            // TODO: Doesn't support "side_of_road" and heading. Then the string waypoint constructor needs to be used. Refactor.
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="polyLine">The <see cref="PolyLine"/>.</param>
        /// <param name="isVia">is prefixed with 'via:'</param>
        public WayPoint(PolyLine polyLine, bool isVia = false)
            : this($"enc:{polyLine}:", isVia)
        {

        }
    }
}