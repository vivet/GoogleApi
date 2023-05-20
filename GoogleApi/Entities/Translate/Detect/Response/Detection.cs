using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Translate.Common.Enums;

namespace GoogleApi.Entities.Translate.Detect.Response;

/// <summary>
/// Language detection result.
/// </summary>
public class Detection
{
    /// <summary>
    /// Indicates whether the language detection result is reliable.
    /// </summary>
    [JsonConverter(typeof(StringBooleanZeroOneJsonConverter))]
    public virtual bool IsReliable { get; set; } = false;

    /// <summary>
    /// The confidence of the detection result for this language.
    /// </summary>
    public virtual double? Confidence { get; set; }

    /// <summary>
    /// The detected language.
    /// </summary>
    public virtual Language Language { get; set; }
}