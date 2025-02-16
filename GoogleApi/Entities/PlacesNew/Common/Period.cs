namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Period.
/// </summary>
public class Period
{
    /// <summary>
    /// Open contains a pair of day and time objects describing when the Place opens.
    /// </summary>
    public virtual Point Open { get; set; }

    /// <summary>
    /// Open contains a pair of day and time objects describing when the Place closes.
    /// </summary>
    public virtual Point Close { get; set; }
}