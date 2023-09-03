using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Information about a transit stop.
/// </summary>
public class TransitStop
{
    /// <summary>
    /// The name of the transit stop.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The location of the stop expressed in latitude/longitude coordinates.
    /// </summary>
    public virtual RouteLocation Location { get; set; }
}