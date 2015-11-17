using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums
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
		ADMINISTRATIVE_AREA_LEVEL_2,
        /// <summary>
        /// Indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_3")]
        ADMINISTRATIVE_AREA_LEVEL_3,
        /// <summary>
        /// Indicates a fourth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_4")]
        ADMINISTRATIVE_AREA_LEVEL_4,
        /// <summary>
        /// Indicates a fifth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_5")]
        ADMINISTRATIVE_AREA_LEVEL_5,
        /// <summary>
        /// Indicates a commonly-used alternative name for the entity.
        /// </summary>
        [EnumMember(Value = "colloquial_area")]
		COLLOQUIAL_AREA,
        /// <summary>
        /// Ward indicates a specific type of Japanese locality, to facilitate distinction between multiple locality components within a Japanese address.
        /// </summary>
        [EnumMember(Value = "ward")]
        WARD,
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
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_1")]
        SUBLOCALITY_LEVEL_1,
        /// <summary>
        /// indicates an second-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_2")]
        SUBLOCALITY_LEVEL_2,
        /// <summary>
        /// indicates an third-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_3")]
        SUBLOCALITY_LEVEL_3,
        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_4")]
        SUBLOCALITY_LEVEL_4,
        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_5")]
        SUBLOCALITY_LEVEL_5,
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
		PARK,
        /// <summary>
        /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
        /// </summary>
        [EnumMember(Value = "point_of_interest")]
		POINT_OF_INTEREST,
        /// <summary>
        /// Indicates the floor of a building address.
        /// </summary>
        [EnumMember(Value = "floor")]
        FLOOR,
        /// <summary>
        /// Establishment typically indicates a place that has not yet been categorized.
        /// </summary>
        [EnumMember(Value = "establishment")]
        ESTABLISHMENT,
        /// <summary>
        /// Parking indicates a parking lot or parking structure.
        /// </summary>
        [EnumMember(Value = "parking")]
        PARKING,
        /// <summary>
        /// post_box indicates a specific postal box.
        /// </summary>
        [EnumMember(Value = "post_box")]
        POST_BOX,
        /// <summary>
        /// postal_town indicates a grouping of geographic areas, such as locality and sublocality, used for mailing addresses in some countries.
        /// </summary>
        [EnumMember(Value = "postal_town")]
        POSTAL_TOWN,
        /// <summary>
        /// room indicates the room of a building address.
        /// </summary>
        [EnumMember(Value = "room")]
        ROOM,
        /// <summary>
        /// street_number indicates the precise street number.
        /// </summary>
        [EnumMember(Value = "street_number")]
        STREET_NUMBER,
        /// <summary>
        /// Indicate the location of a bus stop.
        /// </summary>
        [EnumMember(Value = "bus_station")]
        BUS_STATION,
        /// <summary>
        /// Indicate the location of a train stop.
        /// </summary>
        [EnumMember(Value = "train_station")]
        TRAIN_STATION,
        /// <summary>
        /// Indicate the location of a public transit stop.
        /// </summary>
        [EnumMember(Value = "transit_station")]
        TRANSIT_STATION,
	}
}
