using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// A facet object (refinements) you can use for refining a search.
    /// https://developers.google.com/custom-search/docs/refinements#create
    /// </summary>
    public class Facet
    {
        /// <summary>
        /// The displayable name of the item, which you should use when displaying the item to a human.
        /// </summary>
        [JsonProperty("anchor")]
        public virtual string Anchor { get; set; }

        /// <summary>
        /// The label of the given facet item, which you can use to refine your search.
        /// </summary>
        [JsonProperty("label")]
        public virtual string Label { get; set; }

        /// <summary>
        /// Label With Op.
        /// </summary>
        [JsonProperty("label_with_op")]
        public virtual string LabelWithOp { get; set; }        
    }
}