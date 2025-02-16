using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Response.Converters;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Geo Json Linestring.
/// https://datatracker.ietf.org/doc/html/rfc7946#section-3.1.4
/// </summary>
public class GeoJsonLinestring
{
    /// <summary>
    /// Type.
    /// </summary>
    public virtual string Type { get; set; }

    /// <summary>
    /// Coordinates.
    /// </summary>
    [JsonConverter(typeof(CoordinateTuplesJsonConverter))]
    public virtual IEnumerable<LatLng> Coordinates { get; set; }
}