using System;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Details about the transit stops for the RouteLegStep
/// </summary>
public class TransitStopDetails
{
    /// <summary>
    /// Information about the arrival stop for the step.
    /// </summary>
    public virtual TransitStop ArrivalStop { get; set; }

    /// <summary>
    /// Information about the departure stop for the step.
    /// </summary>
    public virtual TransitStop DepartureStop { get; set; }

    /// <summary>
    /// The estimated time of arrival for the step.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z"
    /// </summary>
    public virtual DateTime? ArrivalTime { get; set; }

    /// <summary>
    /// The estimated time of departure for the step.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    public virtual DateTime? DepartureTime { get; set; }
}