namespace GoogleApi.Entities.PlacesNew.Search.Text.Request;

/// <summary>
/// Specifies a precalculated polyline from the Routes API defining the route to search.
/// Searching along a route is similar to using the locationBias or locationRestriction request option to bias the search results.
/// However, while the locationBias and locationRestriction options let you specify a region to bias the search results,
/// this option lets you bias the results along a trip route.
/// Results are not guaranteed to be along the route provided, but rather are ranked within the search area defined by the polyline and,
/// optionally, by the locationBias or locationRestriction based on minimal detour times from origin to destination.The results might be along an alternate route,
/// especially if the provided polyline does not define an optimal route from origin to destination.
/// </summary>
public class SearchAlongRouteParameters
{
    /// <summary>
    /// Polyline.
    /// </summary>
    public virtual Polyline Polyline { get; set; }

}