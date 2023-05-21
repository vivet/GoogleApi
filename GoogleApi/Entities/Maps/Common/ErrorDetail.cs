using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Error Detail.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// Type.
    /// </summary>
    [JsonPropertyName("@type")]
    public virtual string Type { get; set; }

    /// <summary>
    /// Field Violations.
    /// </summary>
    public virtual IEnumerable<FieldViolations> FieldViolations { get; set; }
}