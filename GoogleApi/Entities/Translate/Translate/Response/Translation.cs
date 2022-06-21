using GoogleApi.Entities.Translate.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Translate.Translate.Response;

/// <summary>
/// Translation result of a supplied text.
/// </summary>
public class Translation
{
    /// <summary>
    /// The source language detected by google when not supplied in the request.
    /// </summary>
    [JsonProperty("translatedText")]
    public virtual string TranslatedText { get; set; }

    /// <summary>
    /// The translation model.
    /// Can be either base for the Phrase-Based Machine Translation(PBMT) model, or nmt for the Neural Machine Translation(NMT) model.
    /// If you did not include a model parameter with your request, then this field is not included in the response.
    /// </summary>
    [JsonProperty("model")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Model Model { get; set; }

    /// <summary>
    /// The source language of the initial request, detected automatically, if no source language was passed within the initial request.
    /// If the source language was passed, auto-detection of the language will not occur and this field will be omitted.
    /// </summary>
    [JsonProperty("detectedSourceLanguage")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Language? DetectedSourceLanguage { get; set; }
}