using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Common.Enums;
using GoogleApi.Entities.PlacesNew.Search.Common;
using GoogleApi.Entities.PlacesNew.Search.Text.Request.Enums;
using PriceLevel = GoogleApi.Entities.PlacesNew.Common.Enums.PriceLevel;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Request;

/// <summary>
/// Text Search (New) returns information about a set of places based on a string — for example, "pizza in New York" or "shoe stores near Ottawa" or "123 Main Street".
/// The service responds with a list of places matching the text string and any location bias that has been set.
/// The service is especially useful for making ambiguous address queries in an automated system,
/// and non-address components of the string may match businesses as well as addresses.Examples of ambiguous address queries are poorly-formatted addresses or requests
/// that include non-address components such as business names.Requests like the first two examples in the following table
/// may return zero results unless a location — such as region, location restriction, or location bias — is set.
/// </summary>
public class PlacesNewTextSearchRequest : BasePlacesNewRequest, IRequestJsonX
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => $"{base.BaseUrl}places:searchText";

    /// <summary>
    /// Required.
    /// The text string on which to search, for example: "restaurant", "123 Main Street", or "best place to visit in San Francisco".
    /// The API returns candidate matches based on this string and orders the results based on their perceived relevance.
    /// (Required).
    /// </summary>
    public virtual string TextQuery { get; set; }

    /// <summary>
    /// Optional.
    /// Restricts the results to places matching the specified type defined by Table A. Only one type may be specified.
    /// https://developers.google.com/maps/documentation/places/web-service/place-types#table-a
    /// </summary>
    public virtual PlaceLocationTypeA? IncludedType { get; set; }

    /// <summary>
    /// Optional.
    /// If set to true, the response includes businesses that visit or deliver to customers directly, but don't have a physical business location.
    /// If set to false, the API returns only businesses with a physical business location.
    /// </summary>
    public virtual bool IncludePureServiceAreaBusinesses { get; set; }

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
    /// Specifies an area to search. This location serves as a bias which means results around the specified location can be returned,
    /// including results outside the specified area.
    /// You can specify locationRestriction or locationBias, but not both.
    /// Think of locationRestriction as specifying the region which the results must be within,
    /// and locationBias as specifying the region that the results will likely be inside or near but can be outside of the area.
    /// Note: If you omit both locationBias and locationRestriction, then the API uses IP biasing by default. With IP biasing,
    /// the API uses the device's IP address to bias the results.
    /// Note: The locationBias parameter can be overridden if the textQuery contains an explicit location such as Market in Barcelona.
    /// In this case, locationBias is ignored.
    /// Can be set to either <see cref="WithinCirle"/> or  <see cref="WithinRectangle"/>.
    /// </summary>
    public virtual BaseWithin LocationBias { get; set; }

    /// <summary>
    /// Optional.
    /// Specifies an area to search. Results outside the specified area are not returned.
    /// Specify the region as a rectangular Viewport.For an example of defining the Viewport, see the description of locationBias.
    /// You can specify locationRestriction or locationBias, but not both.Think of locationRestriction as specifying the region which the results must be within,
    /// and locationBias as specifying the region that the results will likely be inside or near but can be outside of the area.
    /// Note: If you omit both locationBias and locationRestriction, then the API uses IP biasing by default. With IP biasing,
    /// the API uses the IP address of the device to bias the results.
    /// </summary>
    public virtual WithinRectangle LocationRestriction { get; set; }

    /// <summary>
    /// Optional.
    /// Specifies parameters for identifying available electric vehicle (EV) charging connectors and charging rates.
    /// </summary>
    public virtual EvOptions EvOptions { get; set; }

    /// <summary>
    /// Optional.
    /// Restricts results to only those whose average user rating is greater than or equal to this limit.
    /// Values must be between 0.0 and 5.0 (inclusive) in increments of 0.5. For example: 0, 0.5, 1.0, ... , 5.0 inclusive.
    /// Values are rounded up to the nearest 0.5. For example, a value of 0.6 eliminates all results with a rating less than 1.0.
    /// </summary>
    public virtual double? MinRating { get; set; }

    /// <summary>
    /// Optional.
    /// If true, return only those places that are open for business at the time the query is sent.
    /// If false, return all businesses regardless of open status.
    /// Places that don't specify opening hours in the Google Places database are returned if you set this parameter to false.
    /// </summary>
    public virtual bool OpenNow { get; set; } = false;

    /// <summary>
    /// Optional.
    /// Specifies the number of results (between 1 and 20) to display per page.
    /// For example, setting a pageSize value of 5 will return up to 5 results on the first page.
    /// If there are more results that can be returned from the query,
    /// the response includes a nextPageToken that you can pass into a subsequent request to access the next page.
    /// </summary>
    public virtual int PageSize { get; set; } = 20;

    /// <summary>
    /// Optional.
    /// Specifies the nextPageToken from the response body of the previous page.
    /// </summary>
    public virtual string PageToken { get; set; }

    /// <summary>
    /// Optional.
    /// Restrict the search to places that are marked at certain price levels. The default is to select all price levels.
    /// Specify an array of one or more of values defined by PriceLevel.
    /// Note: <see cref="PriceLevel.Free"/> is not allowed in a request. It is only used to populate the response.
    /// </summary>
    public virtual IEnumerable<PriceLevel> PriceLevels { get; set; } = new List<PriceLevel>();

    /// <summary>
    /// Optional.
    /// Specifies how the results are ranked in the response based on the type of query:
    /// For a categorical query such as "Restaurants in New York City", RELEVANCE (rank results by search relevance) is the default.
    /// You can set rankPreference to RELEVANCE or DISTANCE (rank results by distance).
    /// For a non-categorical query such as "Mountain View, CA", we recommend that you leave rankPreference unse
    /// </summary>
    public virtual RankPreference? RankPreference { get; set; }

    /// <summary>
    /// Optional.
    /// The region code used to format the response, specified as a two-character CLDR code value.
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
    /// Used with the includedType parameter.
    /// When set to true, only places that match the specified types specified by includeType are returned.
    /// When false, the default, the response can contain places that don't match the specified types.
    /// </summary>
    public virtual bool StrictTypeFiltering { get; set; } = false;

    /// <summary>
    /// Optional.
    /// Parameters that affect the routing to the search results.
    /// </summary>
    public virtual RoutingParameters RoutingParameters { get; set; }

    /// <summary>
    /// Optional.
    /// Additional parameters proto for searching along a route.
    /// </summary>
    public virtual SearchAlongRouteParameters SearchAlongRouteParameters { get; set; }
}