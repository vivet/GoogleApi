using Newtonsoft.Json;

namespace GoogleApi.Entities.Translate.Detect.Response;

/// <summary>
/// Detect Response.
/// </summary>
public class DetectResponse : BaseResponse
{
    /// <summary>
    /// Container for the detected results.
    /// </summary>
    [JsonProperty("data")]
    public virtual Data Data { get; set; }
}