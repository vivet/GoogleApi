using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    /// <summary>
    /// The list of language translation responses.
    /// This list contains a language translation response for each query (q) sent in the language translation request.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Contains list of translation results of the supplied text.
        /// </summary>
        [JsonProperty("translations")]
        public virtual IEnumerable<Translation> Translations { get; set; }
    }
}