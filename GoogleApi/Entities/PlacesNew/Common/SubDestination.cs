namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Place resource name and id of sub destinations that relate to the place.
/// For example, different terminals are different destinations of an airport.
/// </summary>
public class SubDestination
{
    /// <summary>
    /// The resource name of the sub destination.   
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The place id of the sub destination.
    /// </summary>
    public virtual string Id { get; set; }
}