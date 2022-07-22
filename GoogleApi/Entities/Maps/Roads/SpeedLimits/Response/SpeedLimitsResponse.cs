using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;

/// <summary>
/// SpeedLimits Response.
/// </summary>
public class SpeedLimitsResponse : BaseRoadsResponse
{
    /// <summary>
    /// SpeedLimits — A collection of road metadata.
    /// </summary>
    public virtual IEnumerable<SpeedLimit> SpeedLimits { get; set; }
}