using System.Collections.Generic;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Routes Directions Response.
/// </summary>
public class RoutesDirectionsResponse : BaseRouteResponse
{
    /// <summary>
    /// Routes.
    /// routes, an array of elements of type Route.
    /// The routes array contains one element for each route returned by the API.
    /// The array can contain a maximum of five elements: the default route, the eco-friendly route,
    /// and up to three alternative routes.
    /// </summary>
    public virtual IEnumerable<Route> Routes { get; set; }

    /// <summary>
    /// Geocoding Results.
    /// geocodingResults, an array of elements of type GeocodingResults.
    /// For every location in the request (origin, destination, or intermediate waypoint) that was specified as an address string or as a Plus code,
    /// the API performs a place ID lookup. Each element of this array contains the place ID corresponding to a location.
    /// Locations in the request specified as a place ID or as latitude/longitude coordinates are ignored.
    /// </summary>
    public virtual IEnumerable<GeocodingResults> GeocodingResults { get; set; }

    /// <summary>
    /// Fallback Info.
    /// fallbackInfo, of type FallbackInfo.
    /// If the API is not able to compute a route from all of the input properties, it might fallback to using a different way of computation.
    /// When fallback mode is used, this field contains detailed info about the fallback response. Otherwise this field is unset.
    /// </summary>
    public virtual FallbackInfo FallbackInfo { get; set; }
}