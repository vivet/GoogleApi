using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Route.
/// </summary>
public class Route
{
    /// <summary>
    /// Distance Meters.
    /// The travel distance of the route, in meters.
    /// </summary>
    public virtual int? DistanceMeters { get; set; }

    /// <summary>
    /// Duration.
    /// The length of time needed to navigate the route.
    /// If you set the routingPreference to TRAFFIC_UNAWARE, then this value is the same as staticDuration.
    /// If you set the routingPreference to either TRAFFIC_AWARE or TRAFFIC_AWARE_OPTIMAL, then this value is calculated taking traffic conditions into account.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanConverter))]
    public virtual TimeSpan? Duration { get; set; }

    /// <summary>
    /// Static Duration.
    /// The duration of traveling through the route without taking traffic conditions into consideration.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanConverter))]
    public virtual TimeSpan? StaticDuration { get; set; }

    /// <summary>
    /// Polyline.
    /// The overall route polyline. This polyline will be the combined polyline of all legs.
    /// </summary>
    public virtual Polyline Polyline { get; set; }

    /// <summary>
    /// Description.
    /// A description of the route.
    /// </summary>
    public virtual string Description { get; set; }

    /// <summary>
    /// Viewport.
    /// The viewport bounding box of the polyline.
    /// </summary>
    public virtual Viewport Viewport { get; set; }

    /// <summary>
    /// Route Travel Advisory.
    /// Additional information about the route.
    /// </summary>
    public virtual RouteTravelAdvisory TravelAdvisory { get; set; }

    /// <summary>
    /// Route Token.
    /// Web-safe base64 encoded route token that can be passed to NavigationSDK, which allows the Navigation SDK to reconstruct the route during navigation,
    /// and in the event of rerouting honor the original intention when Routes v2.computeRoutes is called. Customers should treat this token as an opaque blob.
    /// NOTE: Route.route_token is only available for requests that have set ComputeRoutesRequest.routing_preference to TRAFFIC_AWARE or TRAFFIC_AWARE_OPTIMAL.
    /// Route.route_token is also not supported for requests that have Via waypoints.
    /// </summary>
    public virtual string RouteToken { get; set; }

    /// <summary>
    /// Legs.
    /// A collection of legs (path segments between waypoints) that make-up the route.
    /// Each leg corresponds to the trip between two non-via Waypoints.
    /// For example, a route with no intermediate waypoints has only one leg.
    /// A route that includes one non-via intermediate waypoint has two legs.
    /// A route that includes one via intermediate waypoint has one leg.
    /// The order of the legs matches the order of Waypoints from origin to intermediates to destination.
    /// </summary>
    public virtual IEnumerable<RouteLeg> Legs { get; set; }

    /// <summary>
    /// Route Labels.
    /// Labels for the Route that are useful to identify specific properties of the route to compare against others.
    /// </summary>
    [JsonPropertyName("routelabels")]
    public virtual IEnumerable<RouteLabel> Labels { get; set; }

    /// <summary>
    /// Warnings.
    /// An array of warnings to show when displaying the route.
    /// </summary>
    public virtual IEnumerable<string> Warnings { get; set; } = new List<string>();
}