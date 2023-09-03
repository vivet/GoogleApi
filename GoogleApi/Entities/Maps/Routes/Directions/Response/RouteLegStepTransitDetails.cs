namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Additional information for the RouteLegStep related to TRANSIT routes.
/// </summary>
public class RouteLegStepTransitDetails
{
    /// <summary>
    /// Information about the arrival and departure stops for the step.
    /// </summary>
    public virtual TransitStopDetails StopDetails { get; set; }

    /// <summary>
    /// Text representations of properties of the RouteLegStepTransitDetails.
    /// </summary>
    public virtual TransitDetailsLocalizedValues LocalizedValues { get; set; }

    /// <summary>
    /// Specifies the direction in which to travel on this line as marked on the vehicle or at the departure stop.
    /// The direction is often the terminus station.
    /// </summary>
    public virtual string Headsign { get; set; }

    /// <summary>
    /// Specifies the expected time as a duration between departures from the same stop at this time.
    /// For example, with a headway seconds value of 600, you would expect a ten minute wait if you should miss your bus.
    /// </summary>
    public virtual string Headway { get; set; }

    /// <summary>
    /// Information about the transit line used in this step.
    /// </summary>
    public virtual TransitLine TransitLine { get; set; }

    /// <summary>
    /// The number of stops from the departure to the arrival stop.
    /// This count includes the arrival stop, but excludes the departure stop.
    /// For example, if your route leaves from Stop A, passes through stops B and C, and arrives at stop D, stopCount will return 3.
    /// </summary>
    public virtual int StopCount { get; set; }

    /// <summary>
    /// The text that appears in schedules and sign boards to identify a transit trip to passengers.
    /// The text should uniquely identify a trip within a service day.
    /// For example, "538" is the tripShortText of the Amtrak train that leaves San Jose, CA at 15:10 on weekdays to Sacramento, CA.
    /// </summary>
    public virtual string TripShortText { get; set; }
}