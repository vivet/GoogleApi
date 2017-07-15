using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Search.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Text.Response
{
    /// <summary>
    /// Text Result.
    /// </summary>
    [DataContract]
    public class TextResult : BaseResult
    {
        /// <summary>
        /// FormattedAddress is a string containing the human-readable address of this place. Often this address is equivalent to the "postal address". The formatted_address property is only returned for a Text Search.
        /// </summary>
        [JsonProperty("formatted_address")]
        public virtual string FormattedAddress { get; set; }
    }
}