using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;

/// <summary>
/// Plus Code Simple.
/// </summary>
public class BasePlusCode
{
    /// <summary>
    /// Global Code.
    /// </summary>
    [JsonPropertyName("global_code")]
    public virtual string GlobalCode { get; set; }

    /// <summary>
    /// Local Code.
    /// </summary>
    [JsonPropertyName("local_code")]
    public virtual string LocalCode { get; set; }
}