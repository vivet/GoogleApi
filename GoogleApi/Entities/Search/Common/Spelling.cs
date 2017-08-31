using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Encapsulates a corrected query.
    /// </summary>
    public class Spelling
    {
        /// <summary>
        /// The corrected query.
        /// </summary>
        [JsonProperty("correctedQuery")]
        public virtual string CorrectedQuery { get; set; }

        /// <summary>
        /// The corrected query, formatted in HTML.
        /// </summary>
        [JsonProperty("htmlCorrectedQuery")]
        public virtual string HtmlCorrectedQuery { get; set; }
    }
}