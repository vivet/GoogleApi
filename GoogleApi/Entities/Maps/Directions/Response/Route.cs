using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Route Request.
/// </summary>
public class Route
{
    /// <summary>
    /// summary contains a short textual description for the route, suitable for naming and disambiguating the route from alternatives.
    /// </summary>
    public virtual string Summary { get; set; }

    /// <summary>
    /// legs[] contains an array which contains information about a leg of the route, between two locations within the given route. A separate leg will be present for each waypoint or destination specified. (A route with no waypoints will contain exactly one leg within the legs array.) Each leg consists of a series of steps. (See Directions Legs below.)
    /// </summary>
    public virtual IEnumerable<Leg> Legs { get; set; }

    /// <summary>
    /// waypoint_order contains an array indicating the order of any waypoints in the calculated route. This waypoints may be reordered if the request was passed optimize:true within its waypoints parameter.
    /// </summary>
    [JsonPropertyName("waypoint_order")]
    public virtual int[] WaypointOrder { get; set; }

    /// <summary>
    /// overview_path contains an object holding an array of encoded points and levels that represent an approximate (smoothed) path of the resulting directions.
    /// </summary>
    [JsonPropertyName("overview_polyline")]
    public virtual OverviewPolyline OverviewPath { get; set; }

    /// <summary>
    /// copyrights contains the copyrights text to be displayed for this route. You must handle and display this information yourself.
    /// </summary>
    public virtual string Copyrights { get; set; }

    /// <summary>
    /// warnings[] contains an array of warnings to be displayed when showing these directions. You must handle and display these warnings yourself.
    /// </summary>
    public virtual string[] Warnings { get; set; }

    /// <summary>
    /// If present, contains the total fare (that is, the total ticket costs) on this route.
    /// This property is only returned for transit requests and only for transit providers where fare information is available.
    /// </summary>
    public virtual Fare Fare { get; set; }

    /// <summary>
    /// Bounds contains the viewport bounding box of the overview_polyline.
    /// </summary>
    public virtual ViewPort Bounds { get; set; }
}