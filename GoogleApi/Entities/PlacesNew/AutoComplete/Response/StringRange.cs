namespace GoogleApi.Entities.PlacesNew.AutoComplete.Response;

/// <summary>
/// Identifies a substring within a given text.
/// </summary>
public class StringRange
{
    /// <summary>
    /// Zero-based offset of the first Unicode character of the string (inclusive).
    /// </summary>
    public virtual int StartOffset { get; set; }

    /// <summary>
    /// Zero-based offset of the last Unicode character (exclusive).
    /// </summary>
    public virtual int EndOffset { get; set; }
}