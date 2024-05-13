using System.Globalization;

namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// CoordinateEx.
/// </summary>
public class CoordinateEx : Entities.Common.Coordinate
{
    /// <summary>
    /// Heading.
    /// </summary>
    public int? Heading { get; set; }

    /// <summary>
    /// Use Side Of Road.
    /// </summary>
    public bool UseSideOfRoad { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    public CoordinateEx(double latitude, double longitude)
        : base(latitude, longitude)
    {
    }

    /// <summary>
    /// Overrdden ToString method for default conversion to Google compatible string.
    /// If <see cref="UseSideOfRoad"/> is true, 'side_of_road:' will prepended to the location.
    /// If <see cref="UseSideOfRoad"/> is true and <see cref="Heading"/> is not null, the heading will be prepended to the location.
    /// </summary>
    /// <returns>The location string.</returns>
    public override string ToString()
    {
        return this.UseSideOfRoad
            ?
            $"side_of_road:{this.Latitude.ToString(CultureInfo.InvariantCulture)},{this.Longitude.ToString(CultureInfo.InvariantCulture)}"
            : this.Heading.HasValue
                ? $"heading={Heading}:{this.Latitude.ToString(CultureInfo.InvariantCulture)},{this.Longitude.ToString(CultureInfo.InvariantCulture)}"
                : base.ToString();
    }
}