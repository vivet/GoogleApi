using Newtonsoft.Json;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Plus Code.
    /// </summary>
    public class PlusCode
    {
        /// <summary>
        /// Global Code
        /// A 4 character area code and 6 character or longer local code(849VCWC8+R9).
        /// </summary>
        [JsonProperty("global_code")]
        public virtual string GlobalCode { get; set; }

        /// <summary>
        /// Global Code
        /// A 6 character or longer local code with an explicit location (CWC8+R9, Mountain View, CA, USA).
        /// </summary>
        [JsonProperty("compound_code")]
        public virtual string LocalCode { get; set; }
    }
}