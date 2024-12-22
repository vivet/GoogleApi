using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;

namespace GoogleApi.Entities.Maps.Geocoding.Common;

/// <summary>
/// Landmark.
/// The landmarks array contains up to 5 results ranked in order of relevance by taking account of proximity to the requested coordinate,
/// the prevalence of the landmark and its visibility.
/// </summary>
public class Landmark
{
    /// <summary>
    /// The place ID of the landmarks result. See the place ID overview.
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table1
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table2
    /// </summary>
    [JsonPropertyName("place_id")]
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// The display name of the landmark and contains language_code and text.
    /// </summary>
    [JsonPropertyName("display_name")]
    public virtual DisplayName DisplayName { get; set; }

    /// <summary>
    /// the point to point distance in meters between the input coordinate and the landmarks result.
    /// </summary>
    [JsonPropertyName("straight_line_distance_meters")]
    public virtual double? StraightLineDistanceMeters { get; set; }

    /// <summary>
    /// The distance in meters as traveled via the road network(ignoring road restrictions) between the input coordinate and the landmarks result.
    /// </summary>
    [JsonPropertyName("travel_distance_meters")]
    public virtual double? TravelDistanceMeters { get; set; }

    /// <summary>
    /// The estimated relationship between the input coordinate and the landmarks result.
    /// </summary>
    [JsonPropertyName("spatial_relationship")]
    public virtual SpatialRelationship? SpatialRelationship { get; set; }

    /// <summary>
    /// Types.
    /// The Place types of the landmark.
    /// </summary>
    public virtual IEnumerable<PlaceLocationType> Types { get; set; }
}