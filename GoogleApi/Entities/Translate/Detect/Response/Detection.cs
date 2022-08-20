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
    public virtual bool IsReliable { get; set; }

    /// <summary>
    /// The confidence of the detection result for this language.
    /// </summary>
    public virtual double Confidence { get; set; }

    /// <summary>
    /// The detected language.
    /// </summary>
    public virtual Language Language { get; set; }
}