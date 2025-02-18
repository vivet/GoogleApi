namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// The range of highlighted text.
/// </summary>
public class HighlightedTextRange
{
    /// <summary>
    /// Start Index.
    /// </summary>
    public virtual int StartIndex { get; set; }

    /// <summary>
    /// End Index.
    /// </summary>
    public virtual int EndIndex { get; set; }
}