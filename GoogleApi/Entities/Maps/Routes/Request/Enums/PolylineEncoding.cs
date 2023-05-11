using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Request.Enums;

/// <summary>
/// 
/// </summary>
public enum PolylineEncoding
{
    /// <summary>
    /// Specifies a polyline encoded using the polyline encoding algorithm.
    /// </summary>
    [EnumMember(Value = "ENCODED_POLYLINE")]
    EncodedPolyline,

    /// <summary>
    /// Specifies a polyline using the GeoJSON LineString format.
    /// </summary>
    [EnumMember(Value = "GEO_JSON_LINESTRING")]
    GeoJsonLinestring
}