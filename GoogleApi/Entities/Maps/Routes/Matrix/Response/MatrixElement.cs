using System;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Matrix.Response.Enums;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Response;

/// <summary>
/// Matrix Element.
/// </summary>
public class MatrixElement
{
    /// <summary>
    /// Origin Index.
    /// Zero-based index of the origin in the request
    /// </summary>
    public virtual int OriginIndex { get; set; }

    /// <summary>
    /// Destination Index.
    /// Zero-based index of the destination in the request.
    /// </summary>
    public virtual int DestinationIndex { get; set; }

    /// <summary>
    /// Status.
    /// Error status code for this element.
    /// </summary>
    [JsonPropertyName("status")]
    public virtual GeocoderStatus ElementStatus { get; set; }

    /// <summary>
    /// Condition.
    /// Indicates whether the route was found or not. Independent of status.
    /// </summary>
    public virtual RouteMatrixElementCondition Condition { get; set; }

    /// <summary>
    /// Distance Meters.
    /// The travel distance of the route, in meters.
    /// </summary>
    public virtual int DistanceMeters { get; set; }

    /// <summary>
    /// Duration.
    /// The length of time needed to navigate the route.
    /// If you set the routingPreference to TRAFFIC_UNAWARE, then this value is the same as staticDuration.
    /// If you set the routingPreference to either TRAFFIC_AWARE or TRAFFIC_AWARE_OPTIMAL, then this value is calculated taking traffic conditions into account.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanConverter))]
    public virtual TimeSpan Duration { get; set; }

    /// <summary>
    /// Static Duration.
    /// The duration of traveling through the route without taking traffic conditions into consideration.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanConverter))]
    public virtual TimeSpan StaticDuration { get; set; }

    /// <summary>
    /// Route Travel Advisory.
    /// Additional information about the route.
    /// </summary>
    public virtual RouteTravelAdvisory TravelAdvisory { get; set; }

    /// <summary>
    /// Fallback Info.
    /// fallbackInfo, of type FallbackInfo.
    /// If the API is not able to compute a route from all of the input properties, it might fallback to using a different way of computation.
    /// When fallback mode is used, this field contains detailed info about the fallback response. Otherwise this field is unset.
    /// </summary>
    public virtual FallbackInfo FallbackInfo { get; set; }
}