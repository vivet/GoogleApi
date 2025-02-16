using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.AutoComplete.Response;

/// <summary>
/// Text representing a Place or query prediction. The text may be used as is or formatted.
/// </summary>
public class FormattableText
{
    /// <summary>
    /// Text that may be used as is or formatted with matches.
    /// </summary>
    public virtual string Text { get; set; }

    /// <summary>
    /// A list of string ranges identifying where the input request matched in text.
    /// The ranges can be used to format specific parts of text. The substrings may not be exact matches of input if the matching was determined
    /// by criteria other than string matching (for example, spell corrections or transliterations).
    /// These values are Unicode character offsets of text.The ranges are guaranteed to be ordered in increasing offset values.
    /// </summary>
    public virtual IEnumerable<StringRange> Matches { get; set; }
}