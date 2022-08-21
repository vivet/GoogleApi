using Newtonsoft.Json;

namespace GoogleApi.Entities.Translate.Translate.Response;

/// <summary>
/// Translate Response.
/// </summary>
public class TranslateResponse : BaseResponse
{
    /// <summary>
    /// Container for the translated results.
    /// </summary>
    [JsonProperty("data")]
    public virtual Data Data { get; set; }
}