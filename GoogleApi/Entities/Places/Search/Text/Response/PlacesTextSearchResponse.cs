using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Search.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Text.Response
{
    /// <summary>
    /// Places TextSearch Response.
    /// </summary>
    [DataContract]
    public class PlacesTextSearchResponse : BasePlacesSearchResponse
    {
        /// <summary>
        /// Results
        /// </summary>
        [JsonProperty("results")]
        public virtual IEnumerable<TextResult> Results { get; set; }
    }
}