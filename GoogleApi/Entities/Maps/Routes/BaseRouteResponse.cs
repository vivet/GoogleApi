using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes;

/// <summary>
/// Base Route Response.
/// </summary>
public abstract class BaseRouteResponse : BaseResponse
{
    /// <summary>
    /// Error.
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public override string ErrorMessage => this.Error?.Message;

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public override Status? Status => this.Error?.Status ?? Entities.Common.Enums.Status.Ok;
}