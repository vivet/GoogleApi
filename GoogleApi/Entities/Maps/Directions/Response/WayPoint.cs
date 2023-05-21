using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Way Point.
/// </summary>
public class WayPoint
{
    /// <summary>
    /// "geocoder_status" indicates the status code resulting from the geocoding operation.
    /// This field may contain the following values.
    /// </summary>
    [JsonPropertyName("geocoder_status")]
    public virtual Status Status { get; set; }

    /// <summary>
    /// "partial_match" indicates that the geocoder did not return an exact match for the original request,
    /// though it was able to match part of the requested address.
    /// You may wish to examine the original request for misspellings and/or an incomplete address. Partial matches most often occur
    /// for street addresses that do not exist within the locality you pass in the request.
    /// Partial matches may also be returned when a request matches two or more locations in the same locality.For example, "21 Henr St, Bristol, UK" will return a partial match for both Henry Street and Henrietta Street. Note that if a request includes a misspelled address component, the geocoding service may suggest an alternative address. Suggestions triggered in this way will also be marked as a partial match.
    /// </summary>
    [JsonPropertyName("partial_match")]
    [JsonConverter(typeof(StringBooleanZeroOneJsonConverter))]
    public virtual bool PartialMatch { get; set; } = false;

    /// <summary>
    /// is a unique identifier that can be used with other Google APIs.
    /// For example, you can use the place_id from a Google Place Autocomplete response to calculate directions to a local business.
    /// </summary>
    [JsonPropertyName("place_id")]
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// "types" indicates the address type of the geocoding result used for calculating directions.
    /// </summary>
    public virtual IEnumerable<PlaceLocationType> Types { get; set; }
}