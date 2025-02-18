namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Info about the place in which this place is located.
/// </summary>
public class ContainingPlace
{
    /// <summary>
    /// The resource name of the place in which this place is located.  
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The place id of the place in which this place is located.
    /// </summary>
    public virtual string Id { get; set; }
}