using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Prediction
    /// </summary>
    [DataContract]
    public class Prediction
    {
        /// <summary>
        /// Description contains the human-readable name for the returned result. For establishment results, this is usually the business name.
        /// </summary>
        [DataMember(Name = "description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// PlaceId is a textual identifier that uniquely identifies a place. 
        /// To retrieve information about the place, pass this identifier in the placeId field of a Google Places API Web Service request
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Terms contains an array of terms identifying each section of the returned description (a section of the description is generally terminated with a comma). Each entry in the array has a value field, containing the text of the term, and an offset field, defining the start position of this term in the description, measured in Unicode characters.
        /// </summary>
        [DataMember(Name = "terms")]
        public virtual IEnumerable<Term> Terms { get; set; }

        /// <summary>
        /// MatchedSubstring contains an offset value and a length. These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.
        /// </summary>
        [DataMember(Name = "matched_substring")]
        public virtual IEnumerable<MatchedSubstring> MatchedSubstrings { get; set; }

        /// <summary>
        /// types[] is an array indicating the type of the prediction.
        /// </summary>
        [DataMember(Name = "types")]
        public virtual IEnumerable<string> Types { get; set; } // TODO: Enum Type
    }
}