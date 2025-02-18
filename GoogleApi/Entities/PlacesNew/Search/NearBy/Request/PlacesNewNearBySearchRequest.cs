using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Common.Enums;
using GoogleApi.Entities.PlacesNew.Search.Common;
using GoogleApi.Entities.PlacesNew.Search.NearBy.Request.Enums;

namespace GoogleApi.Entities.PlacesNew.Search.NearBy.Request;

/// <summary>
/// A Nearby Search (New) request takes one or more place types, and returns a list of matching places within the specified area.
/// A field mask specifying one or more data types is required. Nearby Search (New) only supports POST requests.
/// </summary>
public class PlacesNewNearBySearchRequest : BasePlacesNewRequest, IRequestJsonX
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => $"{base.BaseUrl}places:searchNearby";

    /// <summary>
    /// Required.
    /// The region to search specified as a circle, defined by center point and radius in meters.
    /// The radius must be between 0.0 and 50000.0, inclusive. The default radius is 0.0.
    /// You must set it in your request to a value greater than 0.0.
    /// (Required).
    /// </summary>
    public virtual WithinCirle LocationRestriction { get; set; }

    /// <summary>
    /// Optional.
    /// A comma-separated list of the place types from Table A to search for.
    /// If this parameter is omitted, places of all types are returned.
    /// https://developers.google.com/maps/documentation/places/web-service/place-types#table-a
    /// </summary>
    public virtual IEnumerable<PlaceLocationTypeA> IncludedTypes { get; set; } = new List<PlaceLocationTypeA>();

    /// <summary>
    /// Optional.
    /// A comma-separated list of place types from Table A to exclude from a search.
    /// If you specify both the includedTypes(such as "school") and the excludedTypes(such as "primary_school") in the request,
    /// then the response includes places that are categorized as "school" but not as "primary_school".
    /// The response includes places that match at least one of the includedTypes and none of the excludedTypes.
    /// If there are any conflicting types, such as a type appearing in both includedTypes and excludedTypes, an INVALID_REQUEST error is returned.
    /// https://developers.google.com/maps/documentation/places/web-service/place-types#table-a
    /// </summary>
    public virtual IEnumerable<PlaceLocationTypeA> ExcludedTypes { get; set; } = new List<PlaceLocationTypeA>();

    /// <summary>
    /// Optional.
    /// A comma-separated list of primary place types from Table A to include in a search.
    /// https://developers.google.com/maps/documentation/places/web-service/place-types#table-a
    /// </summary>
    public virtual IEnumerable<PlaceLocationTypeA> IncludedPrimaryTypes { get; set; } = new List<PlaceLocationTypeA>();

    /// <summary>
    /// Optional.
    /// A comma-separated list of primary place types from Table A to exclude from a search.
    /// If there are any conflicting primary types, such as a type appearing in both includedPrimaryTypes and excludedPrimaryTypes,
    /// an INVALID_ARGUMENT error is returned.
    /// https://developers.google.com/maps/documentation/places/web-service/place-types#table-a
    /// </summary>
    public virtual IEnumerable<PlaceLocationTypeA> ExcludedPrimaryTypes { get; set; } = new List<PlaceLocationTypeA>();

    /// <summary>
    /// Optional.
    /// The language in which to return results.
    /// See the list of supported languages.Google often updates the supported languages, so this list may not be exhaustive.
    /// If languageCode is not supplied, the API defaults to en.If you specify an invalid language code, the API returns an INVALID_ARGUMENT error.
    /// The API does its best to provide a street address that is readable for both the user and locals.To achieve that goal,
    /// it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language.
    /// All other addresses are returned in the preferred language.Address components are all returned in the same language, which is chosen from the first component.
    /// If a name is not available in the preferred language, the API uses the closest match.
    /// The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned.
    /// The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types,
    /// or synonyms that may be valid in one language but not in another.
    /// https://developers.google.com/maps/faq#languagesupport
    /// </summary>
    [JsonPropertyName("languageCode")]
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Optional.
    /// Specifies the maximum number of place results to return.
    /// Must be between 1 and 20 (default) inclusive.
    /// </summary>
    public virtual int MaxResultCount { get; set; } = 20;

    /// <summary>
    /// Optional.
    /// The type of ranking to use. If this parameter is omitted, results are ranked by popularity.
    /// </summary>
    public virtual RankPreference RankPreference { get; set; } = RankPreference.Popularity;

    /// <summary>
    /// Optional.
    /// The region code used to format the response, specified as a two-character CLDR code value.
    /// https://www.unicode.org/cldr/charts/46/supplemental/territory_language_information.html
    /// There is no default value.
    /// If the country name of the formattedAddress field in the response matches the regionCode, the country code is omitted from formattedAddress.
    /// This parameter has no effect on adrFormatAddress, which always includes the country name, or on shortFormattedAddress, which never includes it.
    /// Most CLDR codes are identical to ISO 3166-1 codes, with some notable exceptions.For example, the United Kingdom's ccTLD is "uk" (.co.uk)
    /// while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").
    /// The parameter can affect results based on applicable law.
    /// https://www.unicode.org/cldr/charts/46/supplemental/territory_language_information.html
    /// </summary>
    [JsonPropertyName("regionCode")]
    public virtual string Region { get; set; }

    /// <summary>
    /// Optional.
    /// Parameters that affect the routing to the search results.
    /// </summary>
    public virtual RoutingParameters RoutingParameters { get; set; }
}