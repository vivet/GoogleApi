using System.Runtime.Serialization;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Extensions;

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
        public virtual Language? Language { get; set; }

        [DataMember(Name = "language")]
        protected virtual string LanguageStr
        {
            get => this.Language?.ToCode();
            set => this.Language = value.ToEnum<Language>();
        }
    }
}