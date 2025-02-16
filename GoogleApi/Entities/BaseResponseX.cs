using System.Text.Json.Serialization;
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

    /// <inheritdoc />
    public virtual Status Status { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public virtual string ErrorMessage { get; set; }
}