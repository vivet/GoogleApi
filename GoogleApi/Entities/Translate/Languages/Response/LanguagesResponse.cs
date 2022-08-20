namespace GoogleApi.Entities.Translate.Languages.Response;

/// <summary>
/// Languages Response.
/// </summary>
public class LanguagesResponse : BaseResponse
{
    /// <summary>
    /// Container for the languages results.
    /// </summary>
    public virtual Data Data { get; set; }
}