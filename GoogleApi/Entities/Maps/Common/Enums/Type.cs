using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Location types.
    /// </summary>
	[DataContract]
	public enum LocationType
	{
        /// <summary>
        /// Indicates a precise street address.
        /// </summary>
        [EnumMember(Value = "street_address")]
		STREET_ADDRESS,
        /// <summary>
        /// Indicates a named route (such as "US 101").
        /// </summary>
		[EnumMember(Value = "route")]
		ROUTE,
        /// <summary>
        /// Indicates a major intersection, usually of two major roads.
        /// </summary>
        [EnumMember(Value = "intersection")]
		INTERSECTION,
        /// <summary>
        /// Indicates a political entity. Usually, this type indicates a polygon of some civil administration.
        /// </summary>
        [EnumMember(Value = "political")]
		POLITICAL,
        /// <summary>
        /// Indicates the national political entity, and is typically the highest order type returned by the Geocoder.
        /// </summary>
        [EnumMember(Value = "country")]
		COUNTRY,
        /// <summary>
        /// Indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_1")]
		ADMINISTRATIVE_AREA_LEVEL_1,
        /// <summary>
        /// Indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_2")]
		ADMINISTRATIVE_AEA_LVEL_2,
        /// <summary>
        /// Indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_3")]
		ADMINISTRATIVE_AEA_LEVEL_3, 
        /// <summary>
        /// Indicates a commonly-used alternative name for the entity.
        /// </summary>
        [EnumMember(Value = "colloquial_area")]
		COLLOQUIAL_AREA,
        /// <summary>
        /// Indicates an incorporated city or town political entity.
        /// </summary>
        [EnumMember(Value = "locality")]
        LOCALITY,
        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality")]
		SUBLOCALITY,
        /// <summary>
        /// Indicates a named neighborhood
        /// </summary>
        [EnumMember(Value = "neighborhood")]
		NEIGHBORHOOD,
        /// <summary>
        /// Indicates a named location, usually a building or collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "premise")]
		PREMISE,
        /// <summary>
        /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "subpremise")]
		SUBPREMISE,
        /// <summary>
        /// Indicates a postal code as used to address postal mail within the country.
        /// </summary>
        [EnumMember(Value = "postal_code")]
        POSTAL_CODE,
        /// <summary>
        /// Indicates a prominent natural feature.
        /// </summary>
        [EnumMember(Value = "natural_feature")]
        NATURAL_FEATURE,
        /// <summary>
        /// Indicates an airport.
        /// </summary>
        [EnumMember(Value = "airport")]
        AIRPORT,
        /// <summary>
        /// Indicates a named park.
        /// </summary>
        [EnumMember(Value = "park")]
		Park,
        /// <summary>
        /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
        /// </summary>
        [EnumMember(Value = "point_of_interest")]
		POINT_OF_INTEREST,
        /// <summary>
        /// Indicates a specific postal box.
        /// </summary>
		[EnumMember(Value = "post_box")]
		POST_BOX,
        /// <summary>
        /// Indicates the precise street number.
        /// </summary>
        [EnumMember(Value = "street_number")]
		STREET_NUMBER,
        /// <summary>
        /// Indicates the floor of a building address.
        /// </summary>
        [EnumMember(Value = "floor")]
		FLOOR,
        /// <summary>
        /// Indicates the room of a building address.
        /// </summary>
        [EnumMember(Value = "room")]
		ROOM
	}
}
