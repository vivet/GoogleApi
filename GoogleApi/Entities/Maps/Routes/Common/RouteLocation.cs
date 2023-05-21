using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Route Location.
/// </summary>
public class RouteLocation
{
    /// <summary>
    /// Heading.
    /// The compass heading associated with the direction of the flow of traffic.
    /// This value is used to specify the side of the road to use for pickup and drop-off.
    /// Heading values can be from 0 to 360, where 0 specifies a heading of due North, 90 specifies a heading of due East, etc.
    /// You can use this field only for DRIVE and TWO_WHEELER RouteTravelMode.
    /// </summary>
    public virtual int? Heading { get; set; }

    /// <summary>
    /// Lat Lng.
    /// An object that represents a latitude/longitude pair.
    /// This is expressed as a pair of doubles to represent degrees latitude and degrees longitude.
    /// Unless specified otherwise, this object must conform to the WGS84 standard.
    /// Values must be within normalized ranges.
    /// </summary>
    public virtual LatLng LatLng { get; set; }
}