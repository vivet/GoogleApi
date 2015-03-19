using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesQueryAutoComplete.Response
{
    [DataContract]
    public class MatchedSubstring
    {
        /// <summary>
        /// These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.
        /// </summary>
        [DataMember(Name = "offset")]
        public virtual string Offset { get; set; }

        /// <summary>
        /// These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.
        /// </summary>
        [DataMember(Name = "length")]
        public virtual string Length { get; set; }
    }
}