using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Translate.Languages.Response
{
    /// <summary>
    /// A list of supported language responses.
    /// This list will contain an entry for each language supported by the Translation API    
    /// </summary>
    public class Data
    {
        /// <summary>
        /// The set of supported languages.
        /// </summary>
        [JsonProperty("languages")]
        public virtual IEnumerable<SupportedLanguage> Languages { get; set; }
    }
}