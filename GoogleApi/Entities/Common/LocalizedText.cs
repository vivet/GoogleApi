using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Localized variant of a text in a particular language.
/// </summary>
public class LocalizedText
{
    /// <summary>
    /// Localized string in the language corresponding to `languageCode' below.
    /// </summary>
    public virtual string Text { get; set; }

    /// <summary>
    /// The text's BCP-47 language code, such as "en-US" or "sr-Latn".
    /// For more information, see http://www.unicode.org/reports/tr35/#Unicode_locale_identifier.
    /// </summary>
    [JsonPropertyName("languageCode")]
    public virtual Language? Language { get; set; }
}