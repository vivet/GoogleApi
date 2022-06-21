namespace GoogleApi.Entities.Search.Common.Enums.Extensions;

/// <summary>
/// Site Search Filter Extension.
/// </summary>
public static class SiteSearchFilterExtension
{
    /// <summary>
    /// Converts enum value to string.
    /// </summary>
    /// <param name="siteSearch">The enum to convert.</param>
    /// <returns>The string representation of the enum value for the search request.</returns>
    public static string ToFilterString(this SiteSearchFilter siteSearch)
    {
        return siteSearch switch
        {
            SiteSearchFilter.Include => "i",
            SiteSearchFilter.Exclude => "e",
            _ => "i"
        };
    }
}