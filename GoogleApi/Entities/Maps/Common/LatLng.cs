namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Lat Lng.
/// </summary>
public class LatLng
{
    /// <summary>
    /// Latitude.
    /// The latitude in degrees. It must be in the range [-90.0, +90.0].
    /// </summary>
    public virtual double Latitude { get; set; }

    /// <summary>
    /// Longitude.
    /// The longitude in degrees. It must be in the range [-180.0, +180.0].
    /// </summary>
    public virtual double Longitude { get; set; }
}