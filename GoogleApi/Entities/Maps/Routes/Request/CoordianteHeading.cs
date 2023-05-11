using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Routes.Request;

/// <summary>
/// Coordiante Heading.
/// </summary>
public class CoordianteHeading : Coordinate
{
    /// <summary>
    /// Heading.
    /// The compass heading associated with the direction of the flow of traffic.
    /// This value is used to specify the side of the road to use for pickup and drop-off.
    /// Heading values can be from 0 to 360, where 0 specifies a heading of due North, 90 specifies a heading of due East, etc.
    /// You can use this field only for DRIVE and TWO_WHEELER RouteTravelMode.
    /// </summary>
    public int? Heading { get; set; }

    /// <inheritdoc />
    public CoordianteHeading(double latitude, double longitude)
        : base(latitude, longitude)
    {

    }
}