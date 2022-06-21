using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Enums;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geocoding.Common;

/// <summary>
/// When the geocoder returns results, it places them within a (JSON) results array. Even if the geocoder returns no results (such as if the address doesn't exist) it still returns an empty results array. (XML responses consist of zero or more result elements.)
/// </summary>
public class Result
{
    /// <summary>
    /// place_id is a unique identifier that can be used with other Google APIs.
    /// For example, you can use the place_id in a Google Places API request to get details of a local business, such as phone number,
    /// opening hours, user reviews, and more. See the place ID overview.
    /// </summary>
    [JsonProperty("place_id")]
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// Geometry.
    /// </summary>
    [JsonProperty("geometry")]
    public virtual Geometry Geometry { get; set; }

    /// <summary>
    /// Formatted address is a string containing the human-readable address of this location.
    /// Often this address is equivalent to the "postal address," which sometimes differs from country to country.
    /// (Note that some countries, such as the United Kingdom, do not allow distribution of true postal addresses due to licensing restrictions.)
    /// This address is generally composed of one or more address components.
    /// For example, the address "111 8th Avenue, New York, NY" contains separate address components for "111"
    /// (the street number, "8th Avenue" (the route), "New York" (the city) and "NY" (the US state). These address components contain
    /// additional information as noted below.
    /// </summary>
    [JsonProperty("formatted_address")]
    public virtual string FormattedAddress { get; set; }

    /// <summary>
    /// partial_match indicates that the geocoder did not return an exact match for the original request, though it was able to match part of the requested address.
    /// You may wish to examine the original request for misspellings and/or an incomplete address.
    /// Partial matches most often occur for street addresses that do not exist within the locality you pass in the request.
    /// Partial matches may also be returned when a request matches two or more locations in the same locality.
    /// For example, "21 Henr St, Bristol, UK" will return a partial match for both Henry Street and Henrietta Street.
    /// Note that if a request includes a misspelled address component, the geocoding service may suggest an alternative address. Suggestions triggered in this way will also be marked as a partial match.
    /// </summary>
    [JsonProperty("partial_match")]
    public virtual bool PartialMatch { get; set; }

    /// <summary>
    /// plus_code is an encoded location reference, derived from latitude and longitude coordinates,
    /// that represents an area: 1/8000th of a degree by 1/8000th of a degree(about 14m x 14m at the equator) or smaller.
    /// Plus codes can be used as a replacement for street addresses in places where they do not exist (where buildings are not numbered or streets are not named).
    /// The plus code is formatted as a global code and a compound code:
    /// - global_code is a 4 character area code and 6 character or longer local code(849VCWC8+R9).
    /// - compound_code is a 6 character or longer local code with an explicit location (CWC8+R9, Mountain View, CA, USA).
    /// Typically, both the global code and compound code are returned.However, if the result is in a remote location(for example, an ocean or desert)
    /// only the global code may be returned.
    /// See further details about pkus codes here: https://en.wikipedia.org/wiki/Open_Location_Code and https://plus.codes.
    /// </summary>
    [JsonProperty("plus_code")]
    public virtual Entities.Common.PlusCode PlusCode { get; set; }

    /// <summary>
    /// postcode_localities[] is an array denoting all the localities contained in a postal code.
    /// This is only present when the result is a postal code that contains multiple localities.
    /// </summary>
    [JsonProperty("postcode_localities")]
    public virtual IEnumerable<string> PostcodeLocalities { get; set; }

    /// <summary>
    /// The types[] array indicates the type of the returned result.
    /// This array contains a set of one or more tags identifying the type of feature returned in the result.
    /// For example, a geocode of "Chicago" returns "locality" which indicates that "Chicago" is a city,
    /// and also returns "political" which indicates it is a political entity.
    /// </summary>
    [JsonProperty("types", ItemConverterType = typeof(StringEnumOrDefaultConverter<PlaceLocationType>))]
    public virtual IEnumerable<PlaceLocationType> Types { get; set; }

    /// <summary>
    /// address_components[] is an array containing the separate address components
    /// </summary>
    [JsonProperty("address_components")]
    public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }
}