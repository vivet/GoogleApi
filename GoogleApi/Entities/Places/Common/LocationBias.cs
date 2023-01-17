using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Prefer results in a specified area, by specifying either a radius plus lat/lng,
/// or two lat/lng pairs representing the points of a rectangle.
/// If this parameter is not specified, the API uses IP address biasing by default.
/// </summary>
public class LocationBias
{
    /// <summary>
    /// Coordinate used for circle and point bias.
    /// <see cref="Location"/> takes precedence over <see cref="Bounds"/>.
    /// </summary>
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// The distance (in meters) for cirle bias.
    /// Note that setting a radius biases results to the indicated area, but may not fully restrict results to the specified area.
    /// </summary>
    public virtual double? Radius { get; set; }

    /// <summary>
    /// Bounds used for rectangular bias.
    /// Sets the bias to the defined bounds. 'rectangle:south, west|north, east.'
    /// Note that east/west values are wrapped to the range -180, 180, and north/south values are clamped to the range -90, 90.
    /// </summary>
    public virtual ViewPort Bounds { get; set; }

    /// <summary>
    /// Instructs the API to use IP address biasing.
    /// Pass the string ipbias (this option has no additional parameters).
    /// <see cref="IpBias"/> takes precedence over <see cref="Location"/> and <see cref="Bounds"/>.
    /// </summary>
    public virtual bool IpBias { get; set; } = false;

    /// <inheritdoc />
    public override string ToString()
    {
        return (this.IpBias
            ? "ipbias"
            : this.Location != null
                ? this.Radius.HasValue
                    ? $"circle:{this.Radius}@{this.Location}"
                    : $"point:{this.Location}"
                : this.Bounds != null
                    ? $"rectangle:{this.Bounds.SouthWest}|{this.Bounds.NorthEast}"
                    : null)!;
    }
}