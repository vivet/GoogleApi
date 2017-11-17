using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Places.Add.Request
{
    /// <summary>
    /// Places Add Request.
    /// </summary>
    public class PlacesAddRequest : BasePlacesRequest, IRequestJson
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "add/json";

        /// <summary>
        /// Required. The full text name of the place. Limited to 255 characters.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// The address of the place you wish to add. 
        /// If a place has a well-formatted, human-readable address, it is more likely to pass the moderation process for inclusion in the Google Maps database.
        /// (recommended, to improve chances of passing moderation)
        /// </summary>
        [JsonProperty("address")]
        public virtual string Address { get; set; }

        /// <summary>
        /// Required. The geographical location, specified as latitude and longitude values, of the place you want to add.
        /// </summary>
        [JsonProperty("location")]
        public virtual Location Location { get; set; }

        /// <summary>
        /// The accuracy of the location signal on which this request is based, expressed in meters.
        /// </summary>
        [JsonProperty("accuracy")]
        public virtual int? Accuracy { get; set; }

        /// <summary>
        /// A URL pointing to the authoritative website for this Place, such as a business home page. 
        /// If a Place has a well-formatted website address, it is more likely to pass the moderation process for inclusion in the Google Maps database
        /// (recommended, to improve chances of passing moderation) — 
        /// </summary>
        [JsonProperty("website")]
        public virtual string Website { get; set; }

        /// <summary>
        /// The language in which the place's name is being reported. 
        /// See the list of supported languages and their codes. Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        [JsonProperty("language")]
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// The phone number associated with the place. 
        /// If a place has a well-formatted phone number, it is more likely to pass the moderation process for inclusion in the Google Maps database. 
        /// This number should be in local or international format:
        /// Local format may differ by country. See the Wikipedia article. For example, the local phone number for Google's Sydney, Australia office is (02) 9374 4000.
        /// International format includes the country code, and is prefixed with a plus (+) sign. For example, the international phone number for Google's Sydney, Australia office is +61 2 9374 4000.
        /// (recommended, to improve chances of passing moderation).
        /// </summary>
        [JsonProperty("phone_number")]
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Required. The category in which this place belongs.  While types takes an array, only one type can currently be specified for a place. 
        /// XML requests require a single type element. See the list of supported types for more information.  
        /// If none of the supported types are a match for this place, you may specify other.
        /// </summary>
        [JsonProperty("types", ItemConverterType = typeof(StringEnumConverter))]
        public virtual IEnumerable<PlaceLocationType> Types { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                throw new ArgumentException("Name is required");

            if (this.Location == null)
                throw new ArgumentException("Location is required");

            if (this.Types == null || !this.Types.Any())
                throw new ArgumentException("Types is required. At least one type must be specified");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}