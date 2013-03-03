using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Common.Enums
{
	[DataContract]
	public enum LocationType
	{
		[EnumMember(Value = "street_address")]
		StreetAddress,// indicates a precise street address.
		[EnumMember(Value = "route")]
		Route,// indicates a named route (such as "US 101").
		[EnumMember(Value = "intersection")]
		Intersection,// indicates a major intersection, usually of two major roads.
		[EnumMember(Value = "political")]
		Political,// indicates a political entity. Usually, this type indicates a polygon of some civil administration.
		[EnumMember(Value = "country")]
		Country,// indicates the national political entity, and is typically the highest order type returned by the Geocoder.
		[EnumMember(Value = "administrative_area_level_1")]
		AdministrativeAreaLevel1,// indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels.
		[EnumMember(Value = "administrative_area_level_2")]
		AdministrativeAeaLvel2, // indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
		[EnumMember(Value = "administrative_area_level_3")]
		AdministrativeAeaLevel3, // indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
		[EnumMember(Value = "colloquial_area")]
		ColloquialArea, // indicates a commonly-used alternative name for the entity.
		[EnumMember(Value = "locality")]
		Locality, // indicates an incorporated city or town political entity.
		[EnumMember(Value = "sublocality")]
		Sublocality, // indicates an first-order civil entity below a locality
		[EnumMember(Value = "neighborhood")]
		Neighborhood, // indicates a named neighborhood
		[EnumMember(Value = "premise")]
		Premise, // indicates a named location, usually a building or collection of buildings with a common name
		[EnumMember(Value = "subpremise")]
		Subpremise, // indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name
		[EnumMember(Value = "postal_code")]
		PostalCode, // indicates a postal code as used to address postal mail within the country.
		[EnumMember(Value = "natural_feature")]
		NaturalFeature, // indicates a prominent natural feature.
		[EnumMember(Value = "airport")]
		Airport, // indicates an airport.
		[EnumMember(Value = "park")]
		Park, // indicates a named park.
		[EnumMember(Value = "point_of_interest")]
		PointOfInterest, // indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
		//In addition to the above, address components may exhibit the following types:
		[EnumMember(Value = "post_box")]
		PostBox,// indicates a specific postal box.
		[EnumMember(Value = "street_number")]
		StreetNumber, // indicates the precise street number.
		[EnumMember(Value = "floor")]
		Floor, // indicates the floor of a building address.
		[EnumMember(Value = "room")]
		Room // indicates the room of a building address.
	}
}
