using System.Globalization;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Coordinate.
/// </summary>
public class Coordinate
{
    /// <summary>
    /// Latitude.
    /// </summary>
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude.
    /// </summary>
    [JsonPropertyName("lng")]
    public double Longitude { get; set; }

    /// <summary>
    /// Contructor intializing a location using <paramref name="latitude"/> and <paramref name="longitude"/>.
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    public Coordinate(double latitude, double longitude)
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