using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Label.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// The name of a refinement label, which you can use to refine searches.Don't display this in your user interface; instead, use displayName.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// The display name of a refinement label. This is the name you should display in your user interface.
        /// </summary>
        [JsonProperty("displayName")]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label_with_op")]
        public virtual string LabelWithOp { get; set; }
    }
}