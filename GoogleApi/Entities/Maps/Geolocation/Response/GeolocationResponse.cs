using GoogleApi.Entities.Maps.Common;

using Coordinate = GoogleApi.Entities.Common.Coordinate;

namespace GoogleApi.Entities.Maps.Geolocation.Response;

/// <summary>
/// Geo Location Response.
/// </summary>
public class GeolocationResponse : BaseResponse
{
    /// <summary>
    /// The user’s estimated latitude and longitude, in degrees. Contains one lat and one lng sub field.
    /// </summary>
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// The accuracy of the estimated location, in meters. This represents the radius of a circle around the given location.
    /// </summary>
    public virtual double Accuracy { get; set; }

    /// <summary>
    /// Error, if any occurred.
    /// </summary>
    public virtual Error Error { get; set; }
}