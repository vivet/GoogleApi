using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesAutoComplete.Response
{
    [DataContract]
    public class Term
    {
        /// <summary>
        /// Containing the text of the term
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Defining the start position of this term in the description, measured in Unicode characters
        /// </summary>
        [DataMember(Name = "offset")]
        public string Offset { get; set; }
    }
}