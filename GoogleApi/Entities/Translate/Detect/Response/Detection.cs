using System.Runtime.Serialization;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Translate.Detect.Response
{
    /// <summary>
    /// Language detection result.
    /// </summary>
    [DataContract(Name = "detection")]
    public class Detection
    {
        /// <summary>
        /// Indicates whether the language detection result is reliable.
        /// </summary>
        [DataMember(Name = "isReliable")]
        public virtual bool IsReliable { get; set; }

        /// <summary>
        /// The confidence of the detection result for this language.
        /// </summary>
        [DataMember(Name = "confidence")]
        public virtual double Confidence { get; set; }

        /// <summary>
        /// The detected language.
        /// </summary>
        public virtual Language Language { get; set; }

        [DataMember(Name = "language")]
        protected virtual string LanguageStr
        {
            get => this.Language.ToCode();
            set => this.Language = value.ToEnum<Language>();
        }
    }
}