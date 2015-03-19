using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
	/// <summary>
	/// When the geocoder returns results, it places them within a (JSON) results array. Even if the geocoder returns no results (such as if the address doesn't exist) it still returns an empty results array. (XML responses consist of zero or more result elements.)
	/// </summary>
	[DataContract]
	public class Result
	{
		/// <summary>
		/// The types[] array indicates the type of the returned result. This array contains a set of one or more tags identifying the type of feature returned in the result. For example, a geocode of "Chicago" returns "locality" which indicates that "Chicago" is a city, and also returns "political" which indicates it is a political entity.
		/// </summary>
		[DataMember(Name = "types")]
        public virtual IEnumerable<string> Types { get; set; }

		/// <summary>
		/// formatted_address is a string containing the human-readable address of this location. Often this address is equivalent to the "postal address," which sometimes differs from country to country. (Note that some countries, such as the United Kingdom, do not allow distribution of true postal addresses due to licensing restrictions.) This address is generally composed of one or more address components. For example, the address "111 8th Avenue, New York, NY" contains separate address components for "111" (the street number, "8th Avenue" (the route), "New York" (the city) and "NY" (the US state). These address components contain additional information as noted below.
		/// </summary>
		[DataMember(Name = "formatted_address")]
        public virtual string FormattedAddress { get; set; }

		/// <summary>
		/// address_components[] is an array containing the separate address components
		/// </summary>
		[DataMember(Name = "address_components")]
        public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }

		/// <summary>
		/// geometry contains the following i
		/// </summary>
		[DataMember(Name = "geometry")]
        public virtual Geometry Geometry { get; set; }

	}
}
