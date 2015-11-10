namespace GoogleApi.Entities.Places.AutoComplete.Request.Enums
{
    /// <summary>
    /// You may restrict results from a Place Autocomplete request to be of a certain type by passing a types parameter. 
    /// The parameter specifies a type or a type collection, as listed in the supported types below. If nothing is specified, all types are returned. In general only a single type is allowed. 
    /// The exception is that you can safely mix the geocode and establishment types, but note that this will have the same effect as specifying no types. 
    /// https://developers.google.com/places/supported_types#table3
    /// </summary>
	public enum RestrictPlaceType
	{
        /// <summary>
        /// Geocode instructs the Place Autocomplete service to return only geocoding results, 
        /// rather than business results. Generally, you use this request to disambiguate results where the location specified may be indeterminate.
        /// </summary>
        GEOCODE,
        /// <summary>
        /// Address instructs the Place Autocomplete service to return only geocoding results with a precise address. 
        /// Generally, you use this request when you know the user will be looking for a fully specified address.
        /// </summary>
        ADDRESS,
        /// <summary>
        /// Establishment instructs the Place Autocomplete service to return only business results.
        /// </summary>
        ESTABLISHMENT,
        /// <summary>
        /// The (regions) type collection instructs the Places service to return any result matching the following types: locality, sublocality, postal_code, country, administrative_area_level_1, administrative_area_level_2
        /// </summary>
        REGIONS,
        /// <summary>
        /// The (cities) type collection instructs the Places service to return results that match locality or administrative_area_level_3.
        /// </summary>
        CITIES
	}
}
