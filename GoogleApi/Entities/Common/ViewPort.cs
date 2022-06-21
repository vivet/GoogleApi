using System;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Common;

/// <summary>
/// viewport contains the recommended viewport for displaying the returned result, specified as two latitude,longitude values defining
/// the southwest and northeast corner of the viewport bounding box.
/// Generally the viewport is used to frame a result when displaying it to a user.
/// </summary>
public class ViewPort
{
    /// <summary>
    /// South West.
    /// </summary>
    [JsonProperty("southwest")]
    public virtual Coordinate SouthWest { get; }

    /// <summary>
    /// North East.
    /// </summary>
    [JsonProperty("northeast")]
    public virtual Coordinate NorthEast { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="northEast">The <see cref="Coordinate"/>.</param>
    /// <param name="southWest">The <see cref="Coordinate"/>.</param>
    public ViewPort(Coordinate southWest, Coordinate northEast)
    {
        this.NorthEast = northEast ?? throw new ArgumentNullException(nameof(northEast));
        this.SouthWest = southWest ?? throw new ArgumentNullException(nameof(southWest));
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.SouthWest}|{this.NorthEast}";
    }
}