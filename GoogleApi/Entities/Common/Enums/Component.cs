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
        ROUTE,
        /// <summary>
        /// locality matches against both locality and sublocality types. 
        /// </summary>
        LOCALITY,
        /// <summary>
        /// administrative_area matches all the administrative_area levels. 
        /// </summary>
        ADMINISTRATIVE_AREA,
        /// <summary>
        /// postal_code matches postal_code and postal_code_prefix.
        /// </summary>
        POSTAL_CODE,
        /// <summary>
        /// country matches a country name or a two letter ISO 3166-1 country code.
        /// </summary>
        COUNTRY,
    }
}