using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// A circle is defined by center point and radius in meters.
/// The radius must be between 0.0 and 50000.0, inclusive. The default radius is 0.0.
/// </summary>
public class Circle
{
    /// <summary>
    /// Center.
    /// </summary>
    public virtual LatLng Center { get; set; }

    /// <summary>
    /// Radius.
    /// </summary>
    public virtual int Radius { get; set; }
}