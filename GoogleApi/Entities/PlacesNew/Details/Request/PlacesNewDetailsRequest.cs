using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;
using System.Collections.Generic;
using System;

namespace GoogleApi.Entities.PlacesNew.Details.Request;

/// <summary>
/// Once you have a place ID, you can request more details about a particular establishment or point of interest by initiating a Place Details (New) request.
/// A Place Details (New) request returns more comprehensive information about the indicated place
/// such as its complete address, phone number, user rating and reviews.
/// </summary>
public class PlacesNewDetailsRequest : BasePlacesNewRequest, IRequestQueryStringX
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => $"{base.BaseUrl}/places/{this.PlaceId}";

    /// <summary>
    /// Required.
    /// A textual identifier that uniquely identifies a place, returned from a Text Search (New) or Nearby Search (New).
    /// For more information about place IDs, see the place ID overview.
    /// The string places/PLACE_ID is also called the place resource name.In the response from a Place Details (New), Nearby Search (New),
    /// and Text Search (New) request, this string is contained in the name field of the response.
    /// The standalone place ID is contained in the id field of the response.
    /// Note: In the existing Place Details, the name field of the response contained the human-readable name for the place. In the new API,
    /// that field is now called displayName.
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// Optional.
    /// The language in which to return results.
    /// See the list of supported languages.Google often updates the supported languages, so this list may not be exhaustive.
    /// * If languageCode is not supplied, the API defaults to en.If you specify an invalid language code, the API returns an INVALID_ARGUMENT error.
    /// * The API does its best to provide a street address that is readable for both the user and locals.To achieve that goal,
    /// it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language.
    /// All other addresses are returned in the preferred language.Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another.
    /// Current list of supported languages: https://developers.google.com/maps/faq#languagesupport.
    /// </summary>
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Optional.
    /// The region code used to format the response, specified as a two-character CLDR code value.
    /// https://www.unicode.org/cldr/charts/46/supplemental/territory_language_information.html
    /// There is no default value. If the country name of the formattedAddress field in the response matches the regionCode,
    /// the country code is omitted from formattedAddress.
    /// This parameter has no effect on adrFormatAddress, which always includes the country name, or on shortFormattedAddress, which never includes it.
    /// Most CLDR codes are identical to ISO 3166-1 codes, with some notable exceptions.For example, the United Kingdom's ccTLD is "uk" (.co.uk)
    /// while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").
    /// The parameter can affect results based on applicable law.
    /// </summary>
    public virtual string Region { get; set; }

    /// <summary>
    /// Optional.
    /// Session tokens are user-generated strings that track Autocomplete (New) calls as "sessions."
    /// Autocomplete (New) uses session tokens to group the query and place selection phases of a user autocomplete search into a discrete session for billing purposes.
    /// Session tokens are passed into Place Details (New) calls that follow Autocomplete (New) calls. For more information,
    /// see https://developers.google.com/maps/documentation/places/web-service/place-session-tokens.
    /// </summary>
    public virtual string SessionToken { get; set; }

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (string.IsNullOrWhiteSpace(this.PlaceId))
        {
            throw new ArgumentException($"'{nameof(this.PlaceId)}' is required");
        }

        parameters
            .Add("languageCode", this.Language.ToCode());

        if (!string.IsNullOrEmpty(this.Region))
        {
            parameters
                .Add("regionCode", this.Region);
        }

        if (!string.IsNullOrEmpty(this.SessionToken))
        {
            parameters
                .Add("sessiontoken", this.SessionToken);
        }

        return parameters;
    }
}