using System.Collections.Generic;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Route Leg Step Travel Advisory.
/// Encapsulates the additional information that the user should be informed about, such as possible traffic zone restriction on a leg step.
/// </summary>
public class RouteLegStepTravelAdvisory
{
    /// <summary>
    /// Speed Reading Intervals.
    /// Speed reading intervals detailing traffic density.
    /// Applicable in case of TRAFFIC_AWARE and TRAFFIC_AWARE_OPTIMAL routing preferences.
    /// The intervals cover the entire polyline of the RouteLg without overlap.
    /// The start point of a specified interval is the same as the end point of the preceding interval.
    /// </summary>
    public virtual IEnumerable<SpeedReadingInterval> SpeedReadingIntervals { get; set; }
}