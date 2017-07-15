using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// The location of the entered term in the prediction result text, 
    /// so that the term can be highlighted if desired.
    /// </summary>
    [DataContract(Name = "matched_ubstring")]
    public class MatchedSubstring
    {
        /// <summary>
        /// Offset.
        /// </summary>
        [JsonProperty("offset")]
        public virtual string Offset { get; set; }

        /// <summary>
        /// Length.
        /// </summary>
        [JsonProperty("length")]
        public virtual string Length { get; set; }
    }
}