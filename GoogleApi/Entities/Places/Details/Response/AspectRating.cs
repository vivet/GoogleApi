namespace GoogleApi.Entities.Places.Details.Response;

/// <summary>
/// Aspect Rating.
/// </summary>
public class AspectRating
{
    /// <summary>
    /// Type the name of the aspect that is being rated.
    /// E.g. atmosphere, service, food, overall, etc.
    /// </summary>
    public virtual string Type { get; set; }

    /// <summary>
    /// Rating the user's rating for this particular aspect, from 0 to 3.
    /// </summary>
    public virtual double? Rating { get; set; }
}