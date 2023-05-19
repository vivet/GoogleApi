using System;
using GoogleApi.Entities.Maps.Routes.Common;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Route Leg Step.
/// Encapsulates a segment of a RouteLeg.
/// A step corresponds to a single navigation instruction.
/// Route legs are made up of steps.
/// </summary>
public class RouteLegStep
{
    /// <summary>
    /// Distance Meters.
    /// The travel distance of the route leg, in meters.
    /// </summary>
    public virtual int? DistanceMeters { get; set; }

    /// <summary>
    /// Static Duration.
    /// The duration of traveling through the leg, calculated without taking traffic conditions into consideration.
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanConverter))]
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
    /// Navigation instructions.
    /// </summary>
    public virtual NavigationInstruction NavigationInstruction { get; set; }

    /// <summary>
    /// Travel Advisory.
    /// Encapsulates the additional information that the user should be informed about, such as possible traffic zone restriction on a leg step.
    /// </summary>
    public virtual RouteLegStepTravelAdvisory TravelAdvisory { get; set; }
}