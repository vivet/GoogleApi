using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Text.Response
{
    /// <summary>
    /// Places TextSearch Response.
    /// </summary>
    public class PlacesTextSearchResponse : BasePlacesSearchResponse
    {
        /// <summary>
        /// Results.
        /// </summary>
        [JsonProperty("results")]
        public virtual IEnumerable<TextResult> Results { get; set; }
    }
}