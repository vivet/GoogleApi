using System.Text.Json.Serialization;

using GoogleApi.Entities.Maps.Geocoding.Common.Enums;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Geometry.
/// </summary>
public class Geometry
{
    /// <summary>
    /// Location contains the geocoded latitude,longitude value.
    /// For normal address lookups, this field is typically the most important.
    /// </summary>
    public virtual Coordinate Location { get; set; }

    /// <summary>
    /// Bounds (optionally returned) stores the bounding box which can fully contain the returned result.
    /// Note that these bounds may not match the recommended viewport. (For example, San Francisco includes the Farallon islands,
    /// which are technically part of the city, but probably should not be returned in the viewport.)
    /// </summary>
    public virtual ViewPort Bounds { get; set; }

    /// <summary>
    /// Viewport contains the recommended viewport for displaying the returned result, specified as two latitude,longitude values defining
    /// the southwest and northeast corner of the viewport bounding box.
    /// Generally the viewport is used to frame a result when displaying it to a user.
    /// </summary>
    public virtual ViewPort ViewPort { get; set; }

    /// <summary>
    /// Location type stores additional data about the specified location.
    /// </summary>
    [JsonPropertyName("location_type")]
    public virtual GeometryLocationType LocationType { get; set; }
}