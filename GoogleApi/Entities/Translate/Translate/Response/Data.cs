using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    /// <summary>
    /// The list of language translation responses.
    /// This list contains a language translation response for each query (q) sent in the language translation request.
    /// </summary>
    [DataContract(Name = "Data")]
    public class Data
    {
        /// <summary>
        /// Contains list of translation results of the supplied text.
        /// </summary>
        [DataMember(Name = "translations")]
        public virtual IEnumerable<Translation> Translations { get; set; }
    }
}