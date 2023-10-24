namespace GoogleApi.Entities.Translate.Languages.Response;

/// <summary>
/// Languages Response.
/// </summary>
public class LanguagesResponse : BaseTranslateResponse
{
    /// <summary>
    /// Container for the languages results.
    /// </summary>
    public virtual Data Data { get; set; }
}