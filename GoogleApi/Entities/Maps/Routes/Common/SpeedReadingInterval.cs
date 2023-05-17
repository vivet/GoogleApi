namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Speed Reading Interval.
/// </summary>
public class SpeedReadingInterval
{
    /// <summary>
    /// Start Polyline Point Index.
    /// The starting index of this interval in the polyline.
    /// </summary>
    public virtual int StartPolylinePointIndex { get; set; }

    /// <summary>
    /// End Polyline Point Index.
    /// The ending index of this interval in the polyline.
    /// </summary>
    public virtual int EndPolylinePointIndex { get; set; }

    /// <summary>
    /// Speed.
    /// Traffic speed in this interval.
    /// </summary>
    public virtual Enums.Speed? Speed { get; set; }
}