using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// The text highlighted by the justification. This is a subset of the review itself.
/// The exact word to highlight is marked by the HighlightedTextRange.
/// There could be several words in the text being highlighted.
/// </summary>
public class HighlightedText
{
    /// <summary>
    /// Start Text.
    /// </summary>
    public virtual string Text { get; set; }

    /// <summary>
    /// The list of the ranges of the highlighted text.
    /// </summary>
    public virtual IEnumerable<HighlightedTextRange> HighlightedTextRanges { get; set; }
}