using System.Text.Json.Serialization;

using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Via-WayPoint.
/// </summary>
public class ViaWayPoint
{
    /// <summary>
    /// Location.
    /// </summary>
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// Step Index.
    /// </summary>
    [JsonPropertyName("step_index")]
    public virtual int StepIndex { get; set; }

    /// <summary>
    /// Step Interpolation.
    /// </summary>
    [JsonPropertyName("step_interpolation")]
    public virtual decimal StepInterpolation { get; set; }
}