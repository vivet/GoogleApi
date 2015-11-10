using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Helpers;
using Geometry = GoogleApi.Entities.Places.Common.Geometry;

namespace GoogleApi.Entities.Places.Details.Response
{
    /// <summary>
    /// Details Result.
    /// </summary>
    [DataContract]
    public class DetailsResult
    {
        /// <summary>
        /// address_components[] is an array of separate address components used to compose a given address. For example, 
        /// the address "111 8th Avenue, New York, NY" contains separate address components for "111" (the street number, "8th Avenue" (the route), "New York" (the city) and "NY" (the US state). 
        /// Each address_component typically contains: ◦types[] is an array indicating the type of the address component.
        /// </summary>
        [DataMember(Name = "address_components")]
        public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }

        /// <summary>
        /// Formatted_address is a string containing the human-readable address of this place. Often this address is equivalent to the "postal address," which sometimes differs from country to country. 
        /// This address is generally composed of one or more address_component fields.
        /// </summary>
        [DataMember(Name = "formatted_address")]
        public virtual string FormattedAddress { get; set; }

        /// <summary>
        /// formatted_phone_number contains the Place's phone number in its local format. For example, the formatted_phone_number for Google's Sydney, Australia office is (02) 9374 4000.
        /// </summary>
        [DataMember(Name = "formatted_phone_number")]
        public virtual string FormattedPhoneNumber { get; set; }

        /// <summary>
        /// Geometry contains a location.
        /// </summary>
        [DataMember(Name = "geometry")]
        public virtual Geometry Geometry { get; set; }

        /// <summary>
        /// icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map
        /// </summary>
        [DataMember(Name = "icon")]
        public virtual string Icon { get; set; }

        /// <summary>
        /// international_phone_number contains the Place's phone number in international format. International format includes the country code, and is prefixed with the plus (+) sign. 
        /// For example, the formatted_phone_number for Google's Sydney, Australia office is +61 2 9374 4000. 
        /// </summary>
        [DataMember(Name = "international_phone_number")]
        public virtual string InternationalPhoneNumber { get; set; }

        /// <summary>
        /// name contains the human-readable name for the returned result. For establishment results, this is usually the canonicalized business name.
        /// </summary>
        [DataMember(Name = "name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// opening_hours may contain information about the place opening hours.
        /// </summary>
        [DataMember(Name = "opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// PermanentlyClosed is a boolean flag indicating whether the place has permanently shut down (value true). 
        /// If the place is not permanently closed, the flag is absent from the response.
        /// </summary>
        [DataMember(Name = "permanently_closed")]
        public virtual bool PermanentlyClosed { get; set; }

        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeId field of a Places API request
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// An array of photo objects, each containing a reference to an image. A Place Details request may return up to ten photos.
        /// </summary>
        [DataMember(Name = "photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }

        /// <summary>
        /// Scope — Indicates the scope of the placeId.
        /// Note: The scope field is included only in Nearby Search results and Place Details results. You can only retrieve app-scoped places via the Nearby Search and the Place Details requests. 
        /// If the scope field is not present in a response, it is safe to assume the scope is GOOGLE
        /// </summary>
        public virtual Scope Scope { get; set; }

        [DataMember(Name = "scope")]
        protected virtual string ScopeStr
        {
            get { return EnumHelper.ToEnumString(this.Scope); }
            set { this.Scope = EnumHelper.ToEnum<Scope>(value); }
        }

        /// <summary>
        /// AlternativePlaceIds — An array of zero, one or more alternative place IDs for the place, with a scope related to each alternative ID. Note: This array may be empty or not present. 
        /// If present, it contains the following fields:
        /// </summary>
        [DataMember(Name = "alt_ids")]
        public virtual IEnumerable<AlternativePlace> AlternativePlaceIds { get; set; }

        /// <summary>
        /// price_level — The price level of the place, on a scale of 0 to 4. The exact amount indicated by a specific value will vary from region to region. Price levels are interpreted as follows:
        /// </summary>
        public virtual PriceLevel PriceLevel { get; set; }

        [DataMember(Name = "price_level")]
        protected virtual string PriceLevelStr
        {
            get { return EnumHelper.ToEnumString(this.PriceLevel); }
            set { this.PriceLevel = EnumHelper.ToEnum<PriceLevel>(value); }
        }

        /// <summary>
        /// rating contains the Place's rating, from 0.0 to 5.0, based on user reviews. For more granular ratings, inspect the contents of the aspects collection.
        /// </summary>
        [DataMember(Name = "rating")]
        public virtual double Rating { get; set; }

        /// <summary>
        /// Reviews, array of up to five reviews. 
        /// If a language parameter was specified in the Place Details request, the Places Service will bias the results to prefer reviews written in that language. 
        /// </summary>
        [DataMember(Name = "reviews")]
        public virtual IEnumerable<Review> Review { get; set; }

        /// <summary>
        /// Types contains an array of feature types describing the given result. See the list of supported types for more information. 
        /// XML responses include multiple type elements if more than one type is assigned to the result.
        /// </summary>
        public virtual IEnumerable<PlaceLocationType> Types { get; set; }

        [DataMember(Name = "types")]
        protected virtual IEnumerable<string> TypesStr
        {
            get { return this.Types.Select(EnumHelper.ToEnumString); }
            set
            {
                this.Types = value.Select(EnumHelper.ToEnum<PlaceLocationType>);
            }
        }

        /// <summary>
        /// Url contains the official Google Place Page URL of this establishment. 
        /// Applications must link to or embed the Google Place page on any screen that shows detailed results about this Place to the user.
        /// </summary>
        [DataMember(Name = "url")]
        public virtual string Url { get; set; }

        /// <summary>
        /// Vicinity lists a simplified address for the Place, including the street name, street number, and locality, but not the province/state, postal code, or country. 
        /// For example, Google's Sydney, Australia office has a vicinity value of 48 Pirrama Road, Pyrmont.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public virtual string Vicinity { get; set; }

        /// <summary>
        /// UtcOffset contains the number of minutes this Place’s current timezone is offset from UTC. For example, for Places in Sydney, 
        /// Australia during daylight saving time this would be 660 (+11 hours from UTC), and for Places in California outside of daylight saving time this would be -480 (-8 hours from UTC).
        /// </summary>
        [DataMember(Name = "utc_offset")]
        public virtual int UtcOffset { get; set; }

        /// <summary>
        /// Website lists the authoritative website for this Place, such as a business' homepage.
        /// </summary>
        [DataMember(Name = "website")]
        public virtual string Website { get; set; }
    }
}
