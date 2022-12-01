using System.Collections.Generic;
using System.Text.Json.Serialization;

using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;

namespace GoogleApi.Entities.Places.Details.Response;

/// <summary>
/// Details Result.
/// </summary>
public class DetailsResult
{
    /// <summary>
    /// address_components[] is an array of separate address components used to compose a given address. For example,
    /// the address "111 8th Avenue, New York, NY" contains separate address components for "111" (the street number, "8th Avenue" (the route),
    /// "New York" (the city) and "NY" (the US state).
    /// Each address_component typically contains: ◦types[] is an array indicating the type of the address component.
    /// </summary>
    [JsonPropertyName("address_components")]
    public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }

    /// <summary>
    /// Formatted_address is a string containing the human-readable address of this place. Often this address is equivalent to the "postal address,"
    /// which sometimes differs from country to country.
    /// This address is generally composed of one or more address_component fields.
    /// </summary>
    [JsonPropertyName("formatted_address")]
    public virtual string FormattedAddress { get; set; }

    /// <summary>
    /// formatted_phone_number contains the Place's phone number in its local format.
    /// For example, the formatted_phone_number for Google's Sydney, Australia office is (02) 9374 4000.
    /// </summary>
    [JsonPropertyName("formatted_phone_number")]
    public virtual string FormattedPhoneNumber { get; set; }

    /// <summary>
    /// adr_address is a representation of the place's address in the adr microformat.
    /// http://microformats.org/wiki/adr
    /// </summary>
    [JsonPropertyName("adr_address")]
    public virtual string AdrAddress { get; set; }

    /// <summary>
    /// Geometry contains a location.
    /// </summary>
    public virtual Geometry Geometry { get; set; }

    /// <summary>
    /// icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map
    /// </summary>
    public virtual string Icon { get; set; }

    /// <summary>
    /// international_phone_number contains the Place's phone number in international format. International format includes the country code,
    /// and is prefixed with the plus (+) sign.
    /// For example, the formatted_phone_number for Google's Sydney, Australia office is +61 2 9374 4000.
    /// </summary>
    [JsonPropertyName("international_phone_number")]
    public virtual string InternationalPhoneNumber { get; set; }

    /// <summary>
    /// name contains the human-readable name for the returned result. For establishment results, this is usually the canonicalized business name.
    /// </summary>
    public virtual string Name { get; set; }
    
    /// <summary>
    /// Contains a summary of the place. A summary is comprised of a textual overview, and also includes the language code for these if applicable. Summary text must be presented as-is and can not be modified or altered.
    ///
    /// See PlaceEditorialSummary for more information.
    /// </summary>
    [JsonPropertyName("editorial_summary")]
    public virtual EditorialSummary EditorialSummary { get; set; }

    /// <summary>
    /// opening_hours may contain information about the place opening hours.
    /// </summary>
    [JsonPropertyName("opening_hours")]
    public virtual OpeningHours OpeningHours { get; set; }

    /// <summary>
    /// A textual identifier that uniquely identifies a place. To retrieve information about the place,
    /// pass this identifier in the placeId field of a Places API request
    /// </summary>
    [JsonPropertyName("place_id")]
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// An array of photo objects, each containing a reference to an image. A Place Details request may return up to ten photos.
    /// </summary>
    public virtual IEnumerable<Photo> Photos { get; set; }

    /// <summary>
    /// price_level — The price level of the place, on a scale of 0 to 4.
    /// The exact amount indicated by a specific value will vary from region to region.
    /// Price levels are interpreted as follows:
    /// </summary>
    [JsonPropertyName("price_level")]
    public virtual PriceLevel PriceLevel { get; set; }

    /// <summary>
    /// Business Status.
    /// </summary>
    [JsonPropertyName("business_status")]
    public virtual BusinessStatus BusinessStatus { get; set; }

    /// <summary>
    /// rating contains the Place's rating, from 0.0 to 5.0, based on user reviews.
    /// For more granular ratings, inspect the contents of the aspects collection.
    /// </summary>
    public virtual double Rating { get; set; }

    /// <summary>
    /// The total number of user ratings.
    /// </summary>
    [JsonPropertyName("user_ratings_total")]
    public virtual int UserRatingsTotal { get; set; }

    /// <summary>
    /// Reviews, array of up to five reviews.
    /// If a language parameter was specified in the Place Details request,
    /// the Places Service will bias the results to prefer reviews written in that language.
    /// </summary>
    [JsonPropertyName("reviews")]
    public virtual IEnumerable<Review> Review { get; set; }

    /// <summary>
    /// Types contains an array of feature types describing the given result. See the list of supported types for more information.
    /// XML responses include multiple type elements if more than one type is assigned to the result.
    /// </summary>
    public virtual IEnumerable<PlaceLocationType> Types { get; set; }

    /// <summary>
    /// Url contains the official Google Place Page URL of this establishment.
    /// Applications must link to or embed the Google Place page on any screen that shows detailed results about this Place to the user.
    /// </summary>
    [JsonPropertyName("url")]
    public virtual string Url { get; set; }

    /// <summary>
    /// Vicinity lists a simplified address for the Place, including the street name, street number, and locality, but not the province/state, postal code, or country.
    /// For example, Google's Sydney, Australia office has a vicinity value of 48 Pirrama Road, Pyrmont.
    /// </summary>
    public virtual string Vicinity { get; set; }

    /// <summary>
    /// UtcOffset contains the number of minutes this Place’s current timezone is offset from UTC. For example, for Places in Sydney,
    /// Australia during daylight saving time this would be 660 (+11 hours from UTC), and for Places in California outside of daylight saving time this
    /// would be -480 (-8 hours from UTC).
    /// </summary>
    [JsonPropertyName("utc_offset")]
    public virtual int UtcOffset { get; set; }

    /// <summary>
    /// Website lists the authoritative website for this Place, such as a business' homepage.
    /// </summary>
    public virtual string Website { get; set; }
}
