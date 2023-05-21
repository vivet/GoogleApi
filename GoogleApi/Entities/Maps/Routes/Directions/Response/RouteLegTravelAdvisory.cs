using System.Collections.Generic;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Route Leg Travel Advisory.
/// </summary>
public class RouteLegTravelAdvisory
{
    /// <summary>
    /// Toll Info.
    /// Encapsulates information about tolls on the specific RouteLeg.
    /// This field is only populated if we expect there are tolls on the RouteLeg.
    /// If this field is set but the estimatedPrice subfield is not populated, we expect that road contains tolls but we do not know an estimated price.
    /// If this field does not exist, then there is no toll on the RouteLeg.
    /// </summary>
    public virtual TollInfo TollInfo { get; set; }

    /// <summary>
    /// Speed Reading Intervals.
    /// Speed reading intervals detailing traffic density.
    /// Applicable in case of TRAFFIC_AWARE and TRAFFIC_AWARE_OPTIMAL routing preferences.
    /// The intervals cover the entire polyline of the RouteLg without overlap.
    /// The start point of a specified interval is the same as the end point of the preceding interval.
    /// </summary>
    public virtual IEnumerable<SpeedReadingInterval> SpeedReadingIntervals { get; set; }
}