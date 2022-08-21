namespace GoogleApi.Entities.Places.Details.Response;

/// <summary>
/// Period.
/// </summary>
public class Period
{
    /// <summary>
    /// Open contains a pair of day and time objects describing when the Place opens.
    /// </summary>
    public virtual DayTime Open { get; set; }

    /// <summary>
    /// Open contains a pair of day and time objects describing when the Place closes.
    /// </summary>
    public virtual DayTime Close { get; set; }
}