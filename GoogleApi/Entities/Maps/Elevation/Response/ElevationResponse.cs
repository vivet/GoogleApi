using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Elevation.Response;

/// <summary>
/// Elevation Response.
/// </summary>
public class ElevationResponse : BaseResponse
{
    /// <summary>
    /// Results.
    /// </summary>
    public virtual IEnumerable<Result> Results { get; set; }
}