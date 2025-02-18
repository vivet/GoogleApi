using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// A rectangle is a latitude-longitude viewport, represented as two diagonally opposite low and high points.
/// The low point marks the southwest corner of the rectangle, and the high point represents the northeast corner of the rectangle.
/// A viewport is considered a closed region, meaning it includes its boundary.The latitude bounds must range between -90 to 90 degrees inclusive,
/// and the longitude bounds must range between -180 to 180 degrees inclusive:
/// * If low = high, the viewport consists of that single point.
/// * If low.longitude > high.longitude, the longitude range is inverted (the viewport crosses the 180 degree longitude line).
/// * If low.longitude = -180 degrees and high.longitude = 180 degrees, the viewport includes all longitudes.
/// * If low.longitude = 180 degrees and high.longitude = -180 degrees, the longitude range is empty.
/// * If low.latitude > high.latitude, the latitude range is empty.
/// Both low and high must be populated, and the represented box cannot be empty.An empty viewport results in an error.
/// </summary>
public class Rectangle
{
    /// <summary>
    /// The high point represents the northeast corner of the rectangle.
    /// </summary>
    public virtual LatLng High { get; set; }

    /// <summary>
    /// The low point marks the southwest corner of the rectangle.
    /// </summary>
    public virtual LatLng Low { get; set; }
}