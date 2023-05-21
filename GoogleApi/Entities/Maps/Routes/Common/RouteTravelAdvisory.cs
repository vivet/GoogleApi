using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Route Travel Advisory.
/// </summary>
public class RouteTravelAdvisory
{
    /// <summary>
    /// Toll Info.
    /// ncapsulates information about tolls on the Route.
    /// This field is only populated if we expect there are tolls on the Route.
    /// If this field is set but the estimatedPrice subfield is not populated, we expect that road contains tolls but we do not know an estimated price.
    /// If this field is not set, then we expect there is no toll on the Route.
    /// </summary>
    public virtual TollInfo TollInfo { get; set; }

    /// <summary>
    /// Speed Reading Intervals.
    /// Speed reading intervals detailing traffic density.
    /// Applicable in case of TRAFFIC_AWARE and TRAFFIC_AWARE_OPTIMAL routing preferences.
    /// The intervals cover the entire polyline of the route without overlap.
    /// The start point of a specified interval is the same as the end point of the preceding interval.
    /// </summary>
    public virtual IEnumerable<SpeedReadingInterval> SpeedReadingIntervals { get; set; }

    /// <summary>
    /// Fuel Consumption Microliters.
    /// The fuel consumption prediction in microliters.
    /// </summary>
    public virtual string FuelConsumptionMicroliters { get; set; }
}