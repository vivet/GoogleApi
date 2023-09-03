namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Localized descriptions of values for RouteTransitDetails.
/// </summary>
public class TransitDetailsLocalizedValues
{
    /// <summary>
    /// Time in its formatted text representation with a corresponding time zone.
    /// </summary>
    public virtual LocalizedTime ArrivalTime { get; set; }

    /// <summary>
    /// Time in its formatted text representation with a corresponding time zone.
    /// </summary>
    public virtual LocalizedTime DepartureTime { get; set; }
}