using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities;

/// <summary>
/// Base abstract class for responses.
/// </summary>
public abstract class BaseResponse : IResponse
{
    /// <inheritdoc />
    public virtual string RawJson { get; set; }

    /// <inheritdoc />
    public virtual string RawQueryString { get; set; }

    /// <inheritdoc />
    public virtual Status Status { get; set; }

    /// <inheritdoc />
    [JsonPropertyName("error_message")]
    public virtual string ErrorMessage { get; set; }

    /// <summary>
    /// Info Messages.
    /// </summary>
    [JsonPropertyName("info_messages")]
    public virtual IEnumerable<string> InfoMessages { get; set; }

    /// <summary>
    /// Html Attributions.
    /// </summary>
    [JsonPropertyName("html_attributions")]
    public virtual IEnumerable<string> HtmlAttributions { get; set; }
}