using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// The location of the entered term in the prediction result text, so that the term can be highlighted if desired.
    /// </summary>
    [DataContract]
    public class MatchedSubstring
    {
        /// <summary>
        /// Offset.
        /// </summary>
        [DataMember(Name = "offset")]
        public virtual string Offset { get; set; }

        /// <summary>
        /// Length
        /// </summary>
        [DataMember(Name = "length")]
        public virtual string Length { get; set; }
    }
}