using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Restrict results to a specified area, by specifying either a radius plus lat/lng,
/// or two lat/lng pairs representing the points of a rectangle.
/// </summary>
public class LocationRestriction
{
    /// <summary>
    /// Location used for circle restriction.
    /// <see cref="Location"/> takes precedence over <see cref="Bounds"/>.
    /// </summary>
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// The distance (in meters) used for circle restriction.
    /// Note that setting a radius biases results to the indicated area, but may not fully restrict results to the specified area.
    /// </summary>
    public virtual double? Radius { get; set; }

    /// <summary>
    /// Bounds used for rectangular restriction.
    /// Sets the bias to the defined bounds. 'rectangle:south, west|north, east.'
    /// Note that east/west values are wrapped to the range -180, 180, and north/south values are clamped to the range -90, 90.
    /// </summary>
    public virtual ViewPort Bounds { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        if (this.Location != null)
        {
            if (this.Radius.HasValue)
            {
                return $"circle:{this.Radius}@{this.Location}";
            }
        }
        else if (this.Bounds != null)
        {
            return $"rectangle:{this.Bounds.SouthWest}|{this.Bounds.NorthEast}";
        }

        return null!;
    }
}