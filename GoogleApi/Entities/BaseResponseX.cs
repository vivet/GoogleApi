using System.Text.Json.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities;

/// <summary>
/// Base abstract class for responses.
/// </summary>
public abstract class BaseResponseX : IResponse
{
    /// <inheritdoc />
    public virtual string RawJson { get; set; }

    /// <inheritdoc />
    public virtual string RawQueryString { get; set; }

    /// <summary>
    /// Error.
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public virtual string ErrorMessage => this.Error?.Message;

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public virtual Status Status => this.Error?.Status ?? Status.Ok;
}