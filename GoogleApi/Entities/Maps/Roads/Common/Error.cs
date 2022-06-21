using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Maps.Roads.Common;

/// <summary>
/// Error.
/// </summary>
public class Error
{
    /// <summary>
    /// This is the same as the HTTP status of the response.
    /// </summary>
    [JsonProperty("code")]
    public virtual string Code { get; set; }

    /// <summary>
    /// A short description of the error.
    /// </summary>
    [JsonProperty("message")]
    public virtual string ErrorMessage { get; set; }

    /// <summary>
    /// The status of the request.
    /// See <see cref="Entities.Common.Enums.Status"/>.
    /// </summary>
    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Status Status { get; set; }

    /// <summary>
    /// Error details.
    /// </summary>
    [JsonProperty("details")]
    public virtual IEnumerable<ErrorDetail> Details { get; set; }
}