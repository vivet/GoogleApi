using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
	/// <summary>
	/// When the geocoder returns results, it places them within a (JSON) results array. Even if the geocoder returns no results (such as if the address doesn't exist) it still returns an empty results array. (XML responses consist of zero or more result elements.)
	/// </summary>
	[DataContract]
	public class GeocodeResult
	{
        /// <summary>
        /// The types[] array indicates the type of the returned result. This array contains a set of one or more tags identifying the type of feature returned in the result. For example, a geocode of "Chicago" returns "locality" which indicates that "Chicago" is a city, and also returns "political" which indicates it is a political entity.
        /// </summary>
        public virtual IEnumerable<LocationType> Types { get; set; }

        [DataMember(Name = "types")]
        internal virtual IEnumerable<string> TypesStr
        {
            get { return this.Types.Select(EnumHelper.ToEnumString); }
            set
            {
                this.Types = value.Select(EnumHelper.ToEnum<LocationType>);
            }
        }

        /// <summary>
        /// address_components[] is an array containing the separate address components
        /// </summary>
        [DataMember(Name = "address_components")]
        public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }

		/// <summary>
		/// formatted_address is a string containing the human-readable address of this location. Often this address is equivalent to the "postal address," which sometimes differs from country to country. (Note that some countries, such as the United Kingdom, do not allow distribution of true postal addresses due to licensing restrictions.) This address is generally composed of one or more address components. For example, the address "111 8th Avenue, New York, NY" contains separate address components for "111" (the street number, "8th Avenue" (the route), "New York" (the city) and "NY" (the US state). These address components contain additional information as noted below.
		/// </summary>
		[DataMember(Name = "formatted_address")]
        public virtual string FormattedAddress { get; set; }

		/// <summary>
		/// geometry.
		/// </summary>
		[DataMember(Name = "geometry")]
        public virtual Geometry Geometry { get; set; }

        /// <summary>
        /// place_id is a unique identifier that can be used with other Google APIs. 
        /// For example, you can use the place_id in a Google Places API request to get details of a local business, such as phone number, opening hours, user reviews, and more. See the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// partial_match indicates that the geocoder did not return an exact match for the original request, though it was able to match part of the requested address. 
        /// You may wish to examine the original request for misspellings and/or an incomplete address.
        /// Partial matches most often occur for street addresses that do not exist within the locality you pass in the request. 
        /// Partial matches may also be returned when a request matches two or more locations in the same locality. 
        /// For example, "21 Henr St, Bristol, UK" will return a partial match for both Henry Street and Henrietta Street. 
        /// Note that if a request includes a misspelled address component, the geocoding service may suggest an alternative address. Suggestions triggered in this way will also be marked as a partial match.
        /// </summary>
        [DataMember(Name = "partial_match")]
        public virtual bool PartialMatch { get; set; }

        /// <summary>
        /// postcode_localities[] is an array denoting all the localities contained in a postal code. This is only present when the result is a postal code that contains multiple localities.
        /// </summary>
        [DataMember(Name = "postcode_localities")]
        public virtual IEnumerable<string> PostcodeLocalities { get; set; }
    }
}
