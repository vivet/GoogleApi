using System.Text.Json.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;

/// <summary>
/// Plus Code.
/// </summary>
public class PlusCode : BasePlusCode
{
    /// <summary>
    /// Best Street Address.
    /// </summary>
    [JsonPropertyName("best_street_address")]
    public virtual string BestStreetAddress { get; set; }

    /// <summary>
    /// Locality.
    /// </summary>
    public virtual Locality Locality { get; set; }

    /// <summary>
    /// Locality.
    /// </summary>
    public virtual Geometry Geometry { get; set; }
}