using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	/// <summary>
	/// When the Directions API returns results, it places them within a (JSON) routes array. Even if the service returns no results (such as if the origin and/or destination doesn't exist) it still returns an empty routes array. (XML responses consist of zero or more route elements.)
	/// Each element of the routes array contains a single result from the specified origin and destination. This route may consist of one or more legs depending on whether any waypoints were specified. As well, the route also contains copyright and warning information which must be displayed to the user in addition to the routing information.
	/// </summary>
	[DataContract(Name = "route")]
	public class Route
	{
		/// <summary>
		/// summary contains a short textual description for the route, suitable for naming and disambiguating the route from alternatives.
		/// </summary>
		[DataMember(Name = "summary")]
        public virtual string Summary { get; set; }

		/// <summary>
		/// legs[] contains an array which contains information about a leg of the route, between two locations within the given route. A separate leg will be present for each waypoint or destination specified. (A route with no waypoints will contain exactly one leg within the legs array.) Each leg consists of a series of steps. (See Directions Legs below.)
		/// </summary>
		[DataMember(Name = "legs")]
        public virtual IEnumerable<Leg> Legs { get; set; }

		/// <summary>
		/// waypoint_order contains an array indicating the order of any waypoints in the calculated route. This waypoints may be reordered if the request was passed optimize:true within its waypoints parameter.
		/// </summary>
		[DataMember(Name = "waypoint_order")]
        public virtual int[] WaypointOrder { get; set; }

		/// <summary>
		/// overview_path contains an object holding an array of encoded points and levels that represent an approximate (smoothed) path of the resulting directions.
		/// </summary>
		[DataMember(Name = "overview_polyline")]
        public virtual OverviewPolyline OverviewPath { get; set; }

		/// <summary>
		/// copyrights contains the copyrights text to be displayed for this route. You must handle and display this information yourself.
		/// </summary>
		[DataMember(Name = "copyrights")]
        public virtual string Copyrights { get; set; }

		/// <summary>
		/// warnings[] contains an array of warnings to be displayed when showing these directions. You must handle and display these warnings yourself.
		/// </summary>
		[DataMember(Name = "warnings")]
        public virtual string[] Warnings { get; set; }
	}
}
