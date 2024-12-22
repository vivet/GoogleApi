using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Maps.Geocoding.Common;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;

namespace GoogleApi.Entities.Maps.Geocoding;

/// <summary>
/// Geocode Response.
/// </summary>
public class GeocodeResponse : BaseResponse
{
    /// <summary>
    /// Results.
    /// When the geocoder returns results, it places them within a (JSON) results array.
    /// Even if the geocoder returns no results (such as if the address doesn't exist) it still returns an empty results array.
    /// </summary>
    [JsonPropertyName("results")]
    public virtual IEnumerable<Result> Results { get; set; }

    /// <summary>
    /// Plus Code.
    /// </summary>
    [JsonPropertyName("plus_code")]
    public virtual BasePlusCode PlusCode { get; set; }

    /// <summary>
    /// Address Descriptor.
    /// There are two arrays in each address_descriptor object: landmarks and areas.
    /// </summary>
    [JsonPropertyName("address_descriptor")]
    public virtual AddressDescriptor AddressDescriptor { get; set; }
}