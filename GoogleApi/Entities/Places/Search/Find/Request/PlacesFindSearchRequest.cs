using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;

namespace GoogleApi.Entities.Places.Search.Find.Request;

/// <summary>
/// Places Find Search Request.
/// </summary>
public class PlacesFindSearchRequest : BasePlacesRequest
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => $"{base.BaseUrl}findplacefromtext/json";

    /// <summary>
    /// Input.
    /// The text input specifying which place to search for (for example, a name, address, or phone number)
    /// </summary>
    public virtual string Input { get; set; }

    /// <summary>
    /// Type.
    /// The type of input.This can be one of either textquery or phonenumber.
    /// </summary>
    public virtual InputType Type { get; set; } = InputType.TextQuery;

    /// <summary>
    /// Language (optional).
    /// The language code, indicating in which language the results should be returned, if possible.
    /// Searches are also biased to the selected language; results in the selected language may be given a higher ranking.
    /// See the list of supported languages and their codes: https://developers.google.com/maps/faq#languagesupport
    /// Note that we often update supported languages so this list may not be exhaustive.
    /// </summary>
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Fields (optional).
    /// Defaults to 'place_id'.
    /// The fields specifying the types of place data to return, separated by a comma.
    /// Note, if you omit the fields parameter from a Find Place request, only the place_id for the result will be returned.
    /// </summary>
    public virtual FieldTypes Fields { get; set; } = FieldTypes.Place_Id;

    /// <summary>
    /// Prefer results in a specified area, by specifying either a radius plus lat/lng,
    /// or two lat/lng pairs representing the points of a rectangle.
    /// If this parameter is not specified, the API uses IP address biasing by default.
    /// </summary>
    public virtual LocationBias LocationBias { get; set; }

    /// <summary>
    /// Restrict results to a specified area, by specifying either a radius plus lat/lng,
    /// or two lat/lng pairs representing the points of a rectangle.
    /// </summary>
    public virtual LocationRestriction LocationRestriction { get; set; }

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (string.IsNullOrWhiteSpace(this.Input))
            throw new ArgumentException($"'{nameof(this.Input)}' is required");

        parameters.Add("input", this.Input);
        parameters.Add("inputtype", this.Type.ToString().ToLower());
        parameters.Add("language", this.Language.ToCode());

        var fields = Enum.GetValues(typeof(FieldTypes))
            .Cast<FieldTypes>()
            .Where(x => this.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
            .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

        parameters.Add("fields", fields.EndsWith(",") ? fields.Substring(0, fields.Length - 1) : fields);

        var bias = this.LocationBias?.ToString();
        if (bias != null)
        {
            parameters.Add("locationbias", bias);
        }

        var restriction = this.LocationRestriction?.ToString();
        if (restriction != null)
        {
            parameters.Add("locationrestriction", restriction);
        }

        return parameters;
    }
}