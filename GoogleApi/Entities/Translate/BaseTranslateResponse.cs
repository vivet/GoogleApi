using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Common;

namespace GoogleApi.Entities.Translate;

/// <summary>
/// Base Translate Response (abstract).
/// </summary>
public abstract class BaseTranslateResponse : BaseResponse
{
    /// <summary>
    /// Error.
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public override Status Status => this.Error?.Status ?? base.Status;

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public override string ErrorMessage => this.Error?.Message;
}