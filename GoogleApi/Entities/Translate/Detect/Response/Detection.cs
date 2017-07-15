using System.Runtime.Serialization;
using GoogleApi.Entities.Translate.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        [JsonProperty("isReliable")]
        public virtual bool IsReliable { get; set; }

        /// <summary>
        /// The confidence of the detection result for this language.
        /// </summary>
        [JsonProperty("confidence")]
        public virtual double Confidence { get; set; }

        /// <summary>
        /// The detected language.
        /// </summary>
        [JsonProperty("language")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Language Language { get; set; }
    }
}