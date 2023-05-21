using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.AerialView;

/// <summary>
/// Base Aerial View Response (abstract).
/// </summary>
public abstract class BaseAerialViewResponse : BaseResponse
{
    /// <summary>
    /// Error.
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public override string ErrorMessage => Error?.Message;

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public override Status Status => Error?.Status ?? Status.Ok;
}