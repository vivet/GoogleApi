using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Geolocation.Response;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Translate.Languages.Response
{
    /// <summary>
    /// A single supported language response corresponds to information related to one supported language.
    /// </summary>
    [DataContract(Name = "language")]
    public class SupportedLanguage
    {
        /// <summary>
        /// Human readable name of the language localized to the target language.
        /// </summary>
        [DataMember(Name = "name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Supported language code, generally consisting of its ISO 639-1 identifier. (E.g. 'en', 'ja'). In certain cases, BCP-47 codes 
        /// including language + region identifiers are returned(e.g. 'zh-TW' and 'zh-CH')
        /// </summary>
        [JsonProperty("language")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Language? Language { get; set; }
    }
}