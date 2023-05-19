using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Component Name.
/// A wrapper for the name of the component.
/// </summary>
public class ComponentName
{
    /// <summary>
    /// Text.
    /// The name text. For example, "5th Avenue" for a street name or "1253" for a street number.
    /// </summary>
    public virtual string Text { get; set; }

    /// <summary>
    /// Language.
    /// The BCP-47 language code.
    /// This will not be present if the component name is not associated with a language, such as a street number.
    /// </summary>
    [JsonPropertyName("languageCode")]
    public virtual Language? Language { get; set; }
}