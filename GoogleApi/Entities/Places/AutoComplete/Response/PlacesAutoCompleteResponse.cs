using System.Collections.Generic;
using GoogleApi.Entities.Places.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.AutoComplete.Response;

/// <summary>
/// When the Places service returns JSON results from a search,
/// it places them within a predictions array.
/// </summary>
public class PlacesAutoCompleteResponse : BasePlacesResponse
{
    /// <summary>
    /// Contains an array of predictions, with information about the prediction.
    /// </summary>
    [JsonProperty("predictions")]
    public virtual IEnumerable<Prediction> Predictions { get; set; }
}