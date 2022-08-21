using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;

/// <summary>
/// Plus Code.
/// </summary>
public class PlusCode
{
    /// <summary>
    /// Global Code.
    /// </summary>
    [JsonProperty("global_code")]
    public virtual string GlobalCode { get; set; }

    /// <summary>
    /// Local Code.
    /// </summary>
    [JsonProperty("local_code")]
    public virtual string LocalCode { get; set; }

    /// <summary>
    /// Best Street Address.
    /// </summary>
    [JsonProperty("best_street_address")]
    public virtual string BestStreetAddress { get; set; }

    /// <summary>
    /// Locality.
    /// </summary>
    [JsonProperty("locality")]
    public virtual Locality Locality { get; set; }

    /// <summary>
    /// Locality.
    /// </summary>
    [JsonProperty("geometry")]
    public virtual Geometry Geometry { get; set; }
}