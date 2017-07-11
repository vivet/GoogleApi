using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Languages.Response
{
    /// <summary>
    /// A list of supported language responses.
    /// This list will contain an entry for each language supported by the Translation API    
    /// </summary>
    [DataContract(Name = "data")]
    public class Data
    {
        /// <summary>
        /// The set of supported languages.
        /// </summary>
        [DataMember(Name = "languages")]
        public virtual IEnumerable<SupportedLanguage> Languages { get; set; }
    }
}