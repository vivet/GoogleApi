namespace GoogleApi.Entities.PlacesNew.Search.NearBy.Request;

/// <summary>
/// Route Modifiers.
/// Encapsulates a set of optional conditions to satisfy when calculating the routes.
/// </summary>
public class RouteModifiers
{
    /// <summary>
    /// Specifies whether to avoid toll roads where reasonable.
    /// Preference will be given to routes not containing toll roads.
    /// Applies only to the DRIVE and TWO_WHEELER Travel Mode.
    /// </summary>
    public virtual bool AvoidTolls { get; set; } = false;

    /// <summary>
    /// Specifies whether to avoid highways where reasonable.
    /// Preference will be given to routes not containing highways.
    /// Applies only to the DRIVE and TWO_WHEELER Travel Mode.
    /// </summary>
    public virtual bool AvoidHighways { get; set; } = false;

    /// <summary>
    /// Specifies whether to avoid ferries where reasonable.
    /// Preference will be given to routes not containing travel by ferries.
    /// Applies only to the DRIVE andTWO_WHEELER Travel Mode.
    /// </summary>
    public virtual bool AvoidFerries { get; set; } = false;

    /// <summary>
    /// Specifies whether to avoid navigating indoors where reasonable.
    /// Preference will be given to routes not containing indoor navigation.
    /// Applies only to the WALK Travel Mode.
    /// </summary>
    public virtual bool AvoidIndoor { get; set; } = false;
}