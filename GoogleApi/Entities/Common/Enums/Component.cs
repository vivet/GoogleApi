namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// The components that can be filtered.
/// </summary>
public enum Component
{
    /// <summary>
    /// Route matches long or short name of a route.
    /// </summary>
    Route,

    /// <summary>
    /// Locality matches against both locality and sublocality types.
    /// </summary>
    Locality,

    /// <summary>
    /// Administrative_area matches all the administrative_area levels.
    /// </summary>
    Administrative_Area,

    /// <summary>
    /// Postal_code matches postal_code and postal_code_prefix.
    /// </summary>
    Postal_Code,

    /// <summary>
    /// Country matches a country name or a two letter ISO 3166-1 country code.
    /// </summary>
    Country
}