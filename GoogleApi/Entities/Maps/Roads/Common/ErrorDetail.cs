using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Roads.Common;

/// <summary>
/// Error Detail.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// The type of error.
    /// </summary>
    [JsonPropertyName("@type")]
    public virtual string Type { get; set; }

    /// <summary>
    /// Links associated with the errors.
    /// </summary>
    public virtual IEnumerable<Link> Links { get; set; }
}