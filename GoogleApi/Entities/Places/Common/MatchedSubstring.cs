namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// The location of the entered term in the prediction result text,
/// so that the term can be highlighted if desired.
/// </summary>
public class MatchedSubstring
{
    /// <summary>
    /// Offset.
    /// </summary>
    public virtual string Offset { get; set; }

    /// <summary>
    /// Length.
    /// </summary>
    public virtual string Length { get; set; }
}