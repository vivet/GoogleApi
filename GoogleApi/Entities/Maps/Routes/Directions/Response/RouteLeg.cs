using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Route Leg.
/// Encapsulates a segment between non-via waypoints.
/// </summary>
public class RouteLeg
{
    /// <summary>
    /// Distance Meters.
    /// The travel distance of the route leg, in meters.
    /// </summary>
    public virtual int? DistanceMeters { get; set; }

    /// <summary>
    /// Duration.
    /// The length of time needed to navigate the leg.
    /// If the route_preference is set to TRAFFIC_UNAWARE, then this value is the same as staticDuration.
    /// If the route_preference is either TRAFFIC_AWARE or TRAFFIC_AWARE_OPTIMAL, then this value is calculated taking traffic conditions into account.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanJsonConverter))]
    public virtual TimeSpan? Duration { get; set; }

    /// <summary>
    /// Static Duration.
    /// The duration of traveling through the leg, calculated without taking traffic conditions into consideration.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanJsonConverter))]
    public virtual TimeSpan? StaticDuration { get; set; }

    /// <summary>
    /// Polyline.
    /// The overall polyline for this leg. This includes that each step's polyline.
    /// </summary>
    public virtual Polyline Polyline { get; set; }

    /// <summary>
    /// Start Location.
    /// The start location of this leg. This might be different from the provided origin.
    /// For example, when the provided origin is not near a road, this is a point on the road
    /// </summary>
    public virtual RouteLocation StartLocation { get; set; }

    /// <summary>
    /// End Location.
    /// The end location of this leg. This might be different from the provided destination.
    /// For example, when the provided destination is not near a road, this is a point on the road.
    /// </summary>
    public virtual RouteLocation EndLocation { get; set; }

    /// <summary>
    /// Route Leg Travel Advisory.
    /// Encapsulates the additional information that the user should be informed about, such as possible traffic zone restriction etc. on a route leg.
    /// </summary>
    public virtual RouteLegTravelAdvisory TravelAdvisory { get; set; }

    /// <summary>
    /// Steps.
    /// An array of steps denoting segments within this leg.
    /// Each step represents one navigation instruction.
    /// </summary>
    public virtual IEnumerable<RouteLegStep> Steps { get; set; } = new List<RouteLegStep>();
}