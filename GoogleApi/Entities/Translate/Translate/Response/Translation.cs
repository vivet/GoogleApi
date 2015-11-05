using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    /// <summary>
    /// Translation.
    /// </summary>
    [DataContract(Name = "translation")]
    public class Translation
    {
        /// <summary>
        /// The source language detected by google when not supplied in the request. (optional)
        /// </summary>
        [DataMember(Name = "translatedText")]
        public virtual string TranslatedText { get; set; }

        /// <summary>
        /// The source language detected by google when not supplied in the request. (optional)
        /// </summary>
        [DataMember(Name = "detectedSourceLanguage")]
        public virtual string DetectedSourceLanguage { get; set; }
    }
}