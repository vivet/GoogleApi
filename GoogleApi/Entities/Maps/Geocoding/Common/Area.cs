using System.Text.Json.Serialization;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;

namespace GoogleApi.Entities.Maps.Geocoding.Common;

/// <summary>
/// Area.
/// The areas object contains up to 3 responses and limits itself to places that represent small regions,
/// such as neighborhoods, sublocalities, and large complexes.
/// Areas that contain the requested coordinate are listed first and ordered from smallest to largest.
/// </summary>
public class Area
{
    /// <summary>
    /// The place ID of the areas result. See the place ID overview.
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table1
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table2
    /// </summary>
    [JsonPropertyName("place_id")]
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// The display name of the area and contains language_code and text..
    /// </summary>
    [JsonPropertyName("display_name")]
    public virtual DisplayName DisplayName { get; set; }

    /// <summary>
    /// The containment is the estimated containment relationship between the input coordinate and the areas result
    /// </summary>
    public virtual Containment? Containment { get; set; }
}