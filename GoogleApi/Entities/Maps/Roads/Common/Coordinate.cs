using System.Globalization;

namespace GoogleApi.Entities.Maps.Roads.Common;

/// <summary>
/// Location (Roads only).
/// </summary>
public class Coordinate
{
    /// <summary>
    /// Latitude.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Default Constructor.
    /// </summary>
    public Coordinate()
    {
    }

    /// <summary>
    /// Contructor intializing a valid Location.
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    public Coordinate(double latitude, double longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    /// <summary>
    /// Overrdden ToString method for default conversion to Google compatible string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{this.Latitude.ToString(CultureInfo.InvariantCulture)},{this.Longitude.ToString(CultureInfo.InvariantCulture)}";
    }
}