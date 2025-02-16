using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Routes Directions Response.
/// </summary>
public class RoutesDirectionsResponse : BaseResponseX
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
    /// Contains geocoding response info for waypoints specified as addresses.
    /// </summary>
    public virtual GeocodingResults GeocodingResults { get; set; }

    /// <summary>
    /// Fallback Info.
    /// fallbackInfo, of type FallbackInfo.
    /// If the API is not able to compute a route from all of the input properties, it might fallback to using a different way of computation.
    /// When fallback mode is used, this field contains detailed info about the fallback response. Otherwise this field is unset.
    /// </summary>
    public virtual FallbackInfo FallbackInfo { get; set; }

    /// <summary>
    /// Error.
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public override string ErrorMessage => this.Error?.Message;

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public override Status Status => this.Error?.Status ?? base.Status;
}