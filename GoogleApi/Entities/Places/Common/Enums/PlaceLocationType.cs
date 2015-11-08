using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    /// <summary>
    /// Location types.
    /// </summary>
	[DataContract]
	public enum PlaceLocationType
	{
        /// <summary>
        /// Geocode instructs the Place Autocomplete service to return only geocoding results, 
        /// rather than business results. Generally, you use this request to disambiguate results where the location specified may be indeterminate.
        /// </summary>
        [EnumMember(Value = "geocode")]
        GEOCODE,
        /// <summary>
        /// Address instructs the Place Autocomplete service to return only geocoding results with a precise address. 
        /// Generally, you use this request when you know the user will be looking for a fully specified address.
        /// </summary>
        [EnumMember(Value = "address")]
        ADDRESS,
        /// <summary>
        /// Establishment instructs the Place Autocomplete service to return only business results.
        /// </summary>
        [EnumMember(Value = "establishment")]
        ESTABLISHMENT,
        /// <summary>
        /// The (regions) type collection instructs the Places service to return any result matching the following types: locality, sublocality, postal_code, country, administrative_area_level_1, administrative_area_level_2
        /// </summary>
        [EnumMember(Value = "regions")]
        REGIONS,
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
        /// Indicates a postal code as used to address postal mail within the country.
        /// </summary>
        [EnumMember(Value = "postal_code")]
        POSTAL_CODE,
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
        /// The (cities) type collection instructs the Places service to return results that match locality or administrative_area_level_3.
        /// </summary>
        [EnumMember(Value = "cities")]
		CITIES
	}
}
