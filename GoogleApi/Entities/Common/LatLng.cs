using System.Globalization;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Lat Lng.
/// </summary>
public class LatLng
{
    /// <summary>
    /// Latitude.
    /// The latitude in degrees. It must be in the range [-90.0, +90.0].
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude.
    /// The longitude in degrees. It must be in the range [-180.0, +180.0].
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Default Constructor.
    /// </summary>
    public LatLng()
    {
    }

    /// <summary>
    /// Contructor intializing a valid Location.
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    public LatLng(double latitude, double longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{((decimal)this.Latitude).ToString(CultureInfo.InvariantCulture)},{((decimal)this.Longitude).ToString(CultureInfo.InvariantCulture)}";
    }
}