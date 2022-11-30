using System.Text.Json.Serialization;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Converters;

namespace GoogleApi.Entities.Translate.Languages.Response;

/// <summary>
/// A single supported language response corresponds to information related to one supported language.
/// </summary>
public class SupportedLanguage
{
    /// <summary>
    /// Human readable name of the language localized to the target language.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Supported language code, generally consisting of its ISO 639-1 identifier. (E.g. 'en', 'ja'). In certain cases, BCP-47 codes
    /// including language + region identifiers are returned(e.g. 'zh-TW' and 'zh-CH')
    /// </summary>
    public virtual Language? Language { get; set; }
}