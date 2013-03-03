using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    [DataContract(Name = "translation")]
    public class Translation
    {
        /// <summary>
        /// The source language detected by google when not supplied in the request. (optional)
        /// </summary>
        [DataMember(Name = "translatedText")]
        public string TranslatedText { get; set; }

        /// <summary>
        /// The source language detected by google when not supplied in the request. (optional)
        /// </summary>
        [DataMember(Name = "detectedSourceLanguage")]
        public string DetectedSourceLanguage { get; set; }
    }
}