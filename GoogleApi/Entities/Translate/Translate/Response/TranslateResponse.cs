namespace GoogleApi.Entities.Translate.Translate.Response;

/// <summary>
/// Translate Response.
/// </summary>
public class TranslateResponse : BaseResponse
{
    /// <summary>
    /// Container for the translated results.
    /// </summary>
    public virtual Data Data { get; set; }
}