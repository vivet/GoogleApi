using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// A facet object (refinements) you can use for refining a search.
    /// https://developers.google.com/custom-search/docs/refinements#create
    /// </summary>
    [DataContract]
    public class Facet
    {
        /// <summary>
        /// The displayable name of the item, which you should use when displaying the item to a human.
        /// </summary>
        [DataMember(Name = "anchor")]
        public virtual string Anchor { get; set; }

        /// <summary>
        /// The label of the given facet item, which you can use to refine your search.
        /// </summary>
        [DataMember(Name = "label")]
        public virtual string Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "label_with_op")]
        public virtual string LabelWithOp { get; set; }        
    }
}