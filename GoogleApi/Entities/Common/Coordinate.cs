using System.Globalization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Location.
/// </summary>
public class Coordinate
{
    /// <summary>
    /// Latitude.
    /// </summary>
    [JsonProperty("lat")]
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude.
    /// </summary>
    [JsonProperty("lng")]
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
        return $"{this.Latitude.ToString(CultureInfo.InvariantCulture)},{this.Longitude.ToString(CultureInfo.InvariantCulture)}";
    }
}