using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesAutoComplete.Response
{
    [DataContract]
    public class MatchedSubstring
    {
        /// <summary>
        /// These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.
        /// </summary>
        [DataMember(Name = "offset")]
        public string Offset { get; set; }

        /// <summary>
        /// These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.
        /// </summary>
        [DataMember(Name = "length")]
        public string Length { get; set; }
    }
}