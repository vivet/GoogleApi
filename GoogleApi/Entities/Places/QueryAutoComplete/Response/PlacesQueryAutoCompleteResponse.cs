using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.QueryAutoComplete.Response
{
    /// <summary>
    /// Places QueryAutoComplete Response.
    /// </summary>
    [DataContract]
    public class PlacesQueryAutoCompleteResponse : BasePlacesResponse
    {
        /// <summary>
        /// Contains an array of predictions, with information about the prediction.
        /// </summary>
        [JsonProperty("predictions")]
        public virtual IEnumerable<Prediction> Predictions { get; set; }
    }
}