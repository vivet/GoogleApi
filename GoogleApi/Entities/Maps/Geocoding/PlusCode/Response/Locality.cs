using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;

/// <summary>
/// Locality.
/// </summary>
public class Locality
{
    /// <summary>
    /// Address.
    /// </summary>
    [JsonPropertyName("local_address")]
    public virtual string Address { get; set; }

    /// <summary>
    /// Place Id.
    /// </summary>
    [JsonPropertyName("locality_place_id")]
    public virtual string PlaceId { get; set; }
}