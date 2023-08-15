namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Period.
/// </summary>
public class Period
{
    /// <summary>
    /// Open contains a pair of day and time objects describing when the Place opens.
    /// </summary>
    public virtual PeriodDetail Open { get; set; }

    /// <summary>
    /// Open contains a pair of day and time objects describing when the Place closes.
    /// </summary>
    public virtual PeriodDetail Close { get; set; }
}