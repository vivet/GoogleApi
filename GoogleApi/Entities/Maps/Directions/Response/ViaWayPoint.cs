using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Via-WayPoint.
/// </summary>
public class ViaWayPoint
{
    /// <summary>
    /// Location.
    /// </summary>
    [JsonProperty("location")]
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// Step Index.
    /// </summary>
    [JsonProperty("step_index")]
    public virtual int StepIndex { get; set; }

    /// <summary>
    /// Step Interpolation.
    /// </summary>
    [JsonProperty("step_interpolation")]
    public virtual decimal StepInterpolation { get; set; }
}