using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Error Detail.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// The domain associated with the error.
    /// </summary>
    [JsonPropertyName("domain")]
    public virtual string Doamin { get; set; }  //NOTE:  is this a typo?

    /// <summary>
    /// The error reason.
    /// </summary>
    public virtual string Reason { get; set; }

    /// <summary>
    /// A short description of the error.
    /// </summary>
    [JsonPropertyName("message")]
    public virtual string ErrorMessage { get; set; }
}