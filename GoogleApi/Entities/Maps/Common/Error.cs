using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Common;

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
    /// Collection of errors.
    /// </summary>
    [JsonProperty("errors")]
    public virtual IEnumerable<ErrorDetail> Errors { get; set; }
}