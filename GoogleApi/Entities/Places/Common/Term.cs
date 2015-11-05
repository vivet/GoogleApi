using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Term.
    /// </summary>
    [DataContract]
    public class Term
    {
        /// <summary>
        /// Containing the text of the term
        /// </summary>
        [DataMember(Name = "value")]
        public virtual string Value { get; set; }

        /// <summary>
        /// Defining the start position of this term in the description, measured in Unicode characters
        /// </summary>
        [DataMember(Name = "offset")]
        public virtual string Offset { get; set; }
    }
}