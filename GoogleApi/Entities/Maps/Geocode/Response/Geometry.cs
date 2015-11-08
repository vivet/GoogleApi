using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Geocode.Response.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
    /// <summary>
    /// Geometry.
    /// </summary>
	[DataContract]
	public class Geometry
	{
		/// <summary>
		/// location contains the geocoded latitude,longitude value. For normal address lookups, this field is typically the most important.
		/// </summary>
		[DataMember(Name = "location")]
        public virtual Location Location { get; set; }

		/// <summary>
		/// viewport contains the recommended viewport for displaying the returned result, specified as two latitude,longitude values defining the southwest and northeast corner of the viewport bounding box. Generally the viewport is used to frame a result when displaying it to a user.
		/// </summary>
		[DataMember(Name = "viewport")]
        public virtual ViewPort ViewPort { get; set; }

		/// <summary>
		/// bounds (optionally returned) stores the bounding box which can fully contain the returned result. Note that these bounds may not match the recommended viewport. (For example, San Francisco includes the Farallon islands, which are technically part of the city, but probably should not be returned in the viewport.)
		/// </summary>
		[DataMember(Name = "bounds")]
        public virtual ViewPort Bounds { get; set; }

        /// <summary>
        /// location_type stores additional data about the specified location. 
        /// </summary>
        public virtual GeometryLocationType LocationType { get; set; }

		[DataMember(Name = "location_type")]
        internal virtual string LocationTypeStr
		{
            get { return EnumHelper.ToEnumString(this.LocationType); }
            set { this.LocationType = EnumHelper.ToEnum<GeometryLocationType>(value); }
		}
    }
}
