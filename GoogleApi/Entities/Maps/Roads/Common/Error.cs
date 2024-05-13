using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.Roads.Common;

/// <summary>
/// Error.
/// </summary>
public class Error
{
    /// <summary>
    /// This is the same as the HTTP status of the response.
    /// </summary>
    public virtual int? Code { get; set; }

    /// <summary>
    /// A short description of the error.
    /// </summary>
    [JsonPropertyName("message")]
    public virtual string ErrorMessage { get; set; }

    /// <summary>
    /// The status of the request.
    /// See <see cref="Entities.Common.Enums.Status"/>.
    /// </summary>
    public virtual Status Status { get; set; }

    /// <summary>
    /// Error details.
    /// </summary>
    public virtual IEnumerable<ErrorDetail> Details { get; set; }
}