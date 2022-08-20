using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Structured formatting.
/// </summary>
public class StructuredFormatting
{
    /// <summary>
    /// Main text.
    /// Contains the main text of a prediction, usually the name of the place.
    /// </summary>
    [JsonPropertyName("main_text")]
    public virtual string MainText { get; set; }

    /// <summary>
    /// Main text matched substrings.
    /// Contains an array with offset value and length.
    /// These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.
    /// </summary>
    [JsonPropertyName("main_text_matched_substrings")]
    public virtual IEnumerable<MatchedSubstring> MainTextMatchedSubstrings { get; set; }

    /// <summary>
    /// Secondary text.
    /// Contains the secondary text of a prediction, usually the location of the place.
    /// </summary>
    [JsonPropertyName("secondary_text")]
    public virtual string SecondaryText { get; set; }

    /// <summary>
    /// Secondary text matched substrings.
    /// </summary>
    [JsonPropertyName("secondary_text_matched_substrings")]
    public virtual IEnumerable<MatchedSubstring> SecondaryTextMatchedSubstrings { get; set; }
}