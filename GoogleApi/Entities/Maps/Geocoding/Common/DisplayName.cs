using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.Geocoding.Common;

/// <summary>
/// Display Name.
/// The display name of the landmark and contains language_code and text.
/// </summary>
public class DisplayName
{
    /// <summary>
    /// Text.
    /// </summary>
    public virtual string Text { get; set; }

    /// <summary>
    /// Language Code.
    /// </summary>
    [JsonPropertyName("language_code")]
    public virtual Language LanguageCode { get; set; }
}