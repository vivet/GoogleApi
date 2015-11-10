using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Address Component.
    /// </summary>
	[DataContract]
	public class AddressComponent
	{
        /// <summary>
        /// types[] is an array indicating the type of the address component.
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
