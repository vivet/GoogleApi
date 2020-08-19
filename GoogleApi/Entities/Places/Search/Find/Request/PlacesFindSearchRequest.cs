using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;

namespace GoogleApi.Entities.Places.Search.Find.Request
{
    /// <summary>
    /// Places Find Search Request.
    /// </summary>
    public class PlacesFindSearchRequest : BasePlacesRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "findplacefromtext/json";

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
        /// Fields (optional).
        /// Defaults to 'place_id'.
        /// The fields specifying the types of place data to return, separated by a comma.
        /// Note, if you omit the fields parameter from a Find Place request, only the place_id for the result will be returned.
        /// </summary>
        public virtual FieldTypes Fields { get; set; } = FieldTypes.Place_Id;

        /// <summary>
        /// Language (optional).
        /// The language code, indicating in which language the results should be returned, if possible.
        /// Searches are also biased to the selected language; results in the selected language may be given a higher ranking.
        /// See the list of supported languages and their codes: https://developers.google.com/maps/faq#languagesupport
        /// Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// Radius (optional).
        /// Defines the radius of cirkular location bias.
        /// Ignored if <see cref="Location"/> is null.
        /// </summary>
        public virtual int? Radius { get; set; }

        /// <summary>
        /// Bounds (optional).
        /// Sets the bias to the defined bounds. 'rectangle:south, west|north, east.'
        /// Note that east/west values are wrapped to the range -180, 180, and north/south values are clamped to the range -90, 90.
        /// Ignored if <see cref="Location "/> is not null.
        /// </summary>
        public virtual ViewPort Bounds { get; set; }

        /// <summary>
        /// Location (optional).
        /// The results are biased based on th location (point). If <see cref="Radius"/> is specified as well, the bias is a circle having the center on the location
        /// and the radius in size.
        /// - A single lat/lng coordinate.Use the following format: 'point:lat, lng'
        /// - Circular: A string specifying radius in meters, plus lat/lng in decimal degrees. Format: 'circle:radius @lat, lng.'
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Input))
                throw new ArgumentException("Input is required");

            parameters.Add("input", this.Input);
            parameters.Add("inputtype", this.Type.ToString().ToLower());

            var fields = Enum.GetValues(typeof(FieldTypes))
                .Cast<FieldTypes>()
                .Where(x => this.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

            parameters.Add("fields", fields.EndsWith(",") ? fields.Substring(0, fields.Length - 1) : fields);
            parameters.Add("language", this.Language.ToCode());

            if (this.Location != null)
            {
                parameters.Add("locationbias", this.Radius.HasValue ? $"circle:{this.Radius}@{this.Location}" : $"point:{this.Location}");
            }
            else if (this.Bounds != null)
            {
                parameters.Add("locationbias", $"rectangle:{this.Bounds.SouthWest}|{this.Bounds.NorthEast}");
            }
            else
            {
                parameters.Add("locationbias", "ipbias");
            }

            return parameters;
        }
    }
}
