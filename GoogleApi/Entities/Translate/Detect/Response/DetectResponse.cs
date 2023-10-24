namespace GoogleApi.Entities.Translate.Detect.Response;

/// <summary>
/// Detect Response.
/// </summary>
public class DetectResponse : BaseTranslateResponse
{
    /// <summary>
    /// Container for the detected results.
    /// </summary>
    public virtual Data Data { get; set; }
}