using System.Runtime.Serialization;
using System.Collections.Generic;
using GoogleApi.Entities.Maps.Geocode.Response;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class Result
    {
        /// <summary>
        /// address_components[] is an array of separate address components used to compose a given address. For example, the address "111 8th Avenue, New York, NY" contains separate address components for "111" (the street number, "8th Avenue" (the route), "New York" (the city) and "NY" (the US state). Each address_component typically contains: ◦types[] is an array indicating the type of the address component.
        /// </summary>
        [DataMember(Name = "address_components")]
        public IEnumerable<AddressComponent> AddressComponents { get; set; }

        /// <summary>
        /// An events[] array or one or more event elements provide information about current events happening at this Place. Up to 10 events are returned, ordered by start time. For information about events, please read Events in the Places API.
        /// </summary>
        [DataMember(Name = "events")]
        public IEnumerable<Event> Event { get; set; }

        /// <summary>
        /// Formatted_address is a string containing the human-readable address of this place. Often this address is equivalent to the "postal address," which sometimes differs from country to country. This address is generally composed of one or more address_component fields.
        /// </summary>
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// formatted_phone_number contains the Place's phone number in its local format. For example, the formatted_phone_number for Google's Sydney, Australia office is (02) 9374 4000.
        /// </summary>
        [DataMember(Name = "formatted_phone_number")]
        public string FormattedPhoneNumber { get; set; }

        /// <summary>
        /// Geometry contains a location.
        /// </summary>
        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }

        /// <summary>
        /// icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// id contains a unique stable identifier denoting this place. This identifier may not be used to retrieve information about this place, but can be used to consolidate data about this Place, and to verify the identity of a Place across separate searches. As ids can occasionally change, it's recommended that the stored id for a Place be compared with the id returned in later Details requests for the same Place, and updated if necessary.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// international_phone_number contains the Place's phone number in international format. International format includes the country code, and is prefixed with the plus (+) sign. For example, the formatted_phone_number for Google's Sydney, Australia office is +61 2 9374 4000. 
        /// </summary>
        [DataMember(Name = "international_phone_number")]
        public string InternationalPhoneNumber { get; set; }

        /// <summary>
        /// name contains the human-readable name for the returned result. For establishment results, this is usually the canonicalized business name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// opening_hours may contain information about the place opening hours.
        /// </summary>
        [DataMember(Name = "opening_hours")]
        public OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// rating contains the Place's rating, from 0.0 to 5.0, based on user reviews. For more granular ratings, inspect the contents of the aspects collection.
        /// </summary>
        [DataMember(Name = "rating")]
        public double Rating { get; set; }

        /// <summary>
        /// reference contains a token that can be used to query the Details service in future. This token may differ from the reference used in the request to the Details service. It is recommended that stored references for Places be regularly updated. Although this token uniquely identifies the Place, the converse is not true: a Place may have many valid reference tokens.
        /// </summary>
        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Array of up to five reviews.
        /// </summary>
        [DataMember(Name = "reviews")]
        public IEnumerable<Review> Review { get; set; }

        /// <summary>
        /// types[] contains an array of feature types describing the given result. See the list of supported types for more information. XML responses include multiple type elements if more than one type is assigned to the result.
        /// </summary>
        [DataMember(Name = "types")]
        public string[] Types { get; set; }

        /// <summary>
        /// Url contains the official Google Place Page URL of this establishment. Applications must link to or embed the Google Place page on any screen that shows detailed results about this Place to the user.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// UtcOffset contains the number of minutes this Place’s current timezone is offset from UTC. For example, for Places in Sydney, Australia during daylight saving time this would be 660 (+11 hours from UTC), and for Places in California outside of daylight saving time this would be -480 (-8 hours from UTC).
        /// </summary>
        [DataMember(Name = "utc_offset")]
        public int UtcOffset { get; set; }

        /// <summary>
        /// Vicinity lists a simplified address for the Place, including the street name, street number, and locality, but not the province/state, postal code, or country. For example, Google's Sydney, Australia office has a vicinity value of 48 Pirrama Road, Pyrmont.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public string Vicinity { get; set; }

        /// <summary>
        /// Website lists the authoritative website for this Place, such as a business' homepage.
        /// </summary>
        [DataMember(Name = "website")]
        public string Website { get; set; }
    }
}
