using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Encapsulates a corrected query.
    /// </summary>
    [DataContract]
    public class Spelling
    {
        /// <summary>
        /// The corrected query.
        /// </summary>
        [DataMember(Name = "correctedQuery")]
        public virtual string CorrectedQuery { get; set; }

        /// <summary>
        /// The corrected query, formatted in HTML.
        /// </summary>
        [DataMember(Name = "htmlCorrectedQuery")]
        public virtual string HtmlCorrectedQuery { get; set; }
    }
}