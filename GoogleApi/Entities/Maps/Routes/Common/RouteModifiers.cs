using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Route Modifiers.
/// Encapsulates a set of optional conditions to satisfy when calculating the routes.
/// </summary>
public class RouteModifiers
{
    /// <summary>
    /// Specifies whether to avoid toll roads where reasonable.
    /// Preference will be given to routes not containing toll roads.
    /// Applies only to the DRIVE and TWO_WHEELER TravelMode.
    /// </summary>
    public virtual bool AvoidTolls { get; set; } = false;

    /// <summary>
    /// Specifies whether to avoid highways where reasonable.
    /// Preference will be given to routes not containing highways.
    /// Applies only to the DRIVE and TWO_WHEELER TravelMode.
    /// </summary>
    public virtual bool AvoidHighways { get; set; } = false;

    /// <summary>
    /// Specifies whether to avoid ferries where reasonable.
    /// Preference will be given to routes not containing travel by ferries.
    /// Applies only to the DRIVE andTWO_WHEELER TravelMode.
    /// </summary>
    public virtual bool AvoidFerries { get; set; } = false;

    /// <summary>
    /// Specifies whether to avoid navigating indoors where reasonable.
    /// Preference will be given to routes not containing indoor navigation.
    /// Applies only to the WALK RouteTravelMode.
    /// </summary>
    public virtual bool AvoidIndoor { get; set; } = false;

    /// <summary>
    /// Vehicle Info.
    /// Specifies the vehicle information.
    /// </summary>
    public virtual VehicleInfo VehicleInfo { get; set; }

    /// <summary>
    /// Toll Pass.
    /// Encapsulates information about toll passes.
    /// If toll passes are provided, the API tries to return the pass price.
    /// If toll passes are not provided, the API treats the toll pass as unknown and tries to return the cash price.
    /// Applies only to the DRIVE and TWO_WHEELER TravelMode.
    /// https://developers.google.com/maps/documentation/routes/reference/rest/v2/RouteModifiers#TollPass
    /// </summary>
    public virtual IEnumerable<string> TollPasses { get; set; }
}