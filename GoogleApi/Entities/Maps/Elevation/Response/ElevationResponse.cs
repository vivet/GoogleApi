using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Elevation.Response;

/// <summary>
/// Elevation Response.
/// </summary>
public class ElevationResponse : BaseResponse
{
    /// <summary>
    /// Results.
    /// </summary>
    [JsonProperty("results")]
    public virtual IEnumerable<Result> Results { get; set; }
}