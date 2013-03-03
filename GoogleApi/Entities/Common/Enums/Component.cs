namespace GoogleApi.Entities.Common.Enums
{
    /// <summary>
    /// The components that can be filtered include:
    /// </summary>
    public enum Component
    {
        /// <summary>
        /// route matches long or short name of a route.
        /// </summary>
        Route,
        /// <summary>
        /// locality matches against both locality and sublocality types. 
        /// </summary>
        Locality,
        /// <summary>
        /// administrative_area matches all the administrative_area levels. 
        /// </summary>
        Administrative_area,
        /// <summary>
        /// postal_code matches postal_code and postal_code_prefix.
        /// </summary>
        Postal_code,
        /// <summary>
        /// country matches a country name or a two letter ISO 3166-1 country code.
        /// </summary>
        Country,
    }
}