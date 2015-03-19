using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
	[DataContract]
	public class AddressComponent
	{
		/// <summary>
		/// types[] is an array indicating the type of the address component.
		/// </summary>
		[DataMember(Name = "types")]
        public virtual IEnumerable<string> Types { get; set; }
		/// <summary>
		/// short_name is an abbreviated textual name for the address component, if available. For example, an address component for the state of Alaska may have a long_name of "Alaska" and a short_name of "AK" using the 2-letter postal abbreviation.
		/// </summary>
		[DataMember(Name = "short_name")]
        public virtual string ShortName { get; set; }
		/// <summary>
		/// long_name is the full text description or name of the address component as returned by the Geocoder.
		/// </summary>
		[DataMember(Name = "long_name")]
        public virtual string LongName { get; set; }

	}
}
