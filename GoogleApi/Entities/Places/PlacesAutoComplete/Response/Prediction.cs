using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesAutoComplete.Response
{
    [DataContract]
    public class Prediction
    {
        /// <summary>
        /// Description contains the human-readable name for the returned result. For establishment results, this is usually the business name.
        /// </summary>
        [DataMember(Name = "description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Reference contains a unique token that you can use to retrieve additional information about this place in a Place Details request. You can store this token and use it at any time in future to refresh cached data about this Place, but the same token is not guaranteed to be returned for any given Place across different searches.
        /// </summary>
        [DataMember(Name = "reference")]
        public virtual string Reference { get; set; }

        /// <summary>
        /// Id contains a unique stable identifier denoting this place. This identifier may not be used to retrieve information about this place, but can be used to consolidate data about this Place, and to verify the identity of a Place across separate searches.
        /// </summary>
        [DataMember(Name = "id")]
        public virtual string Id { get; set; }

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
        public virtual IEnumerable<string> Types { get; set; }
    }
}