namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Polyline.
/// Union field polyline_type.
/// Encapsulates the type of polyline.
/// Defaults to encoded_polyline. polyline_type can be only one of the following:
/// - encodedPolyline
/// - geoJsonLinestring
/// </summary>
public class Polyline
{
    /// <summary>
    /// Encoded Polyline.
    /// The string encoding of the polyline using the polyline encoding algorithm.
    /// https://developers.google.com/maps/documentation/utilities/polylinealgorithm
    /// </summary>
    public virtual string EncodedPolyline { get; set; }

    /// <summary>
    /// Geo Json Linestring.
    /// Specifies a polyline using the GeoJSON LineString format.
    /// https://datatracker.ietf.org/doc/html/rfc7946#section-3.1.4
    /// </summary>
    public virtual GeoJsonLinestring GeoJsonLinestring { get; set; }
}