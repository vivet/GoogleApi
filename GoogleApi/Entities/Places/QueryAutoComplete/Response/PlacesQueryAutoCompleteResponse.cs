using System.Collections.Generic;

using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.QueryAutoComplete.Response;

/// <summary>
/// Places QueryAutoComplete Response.
/// </summary>
public class PlacesQueryAutoCompleteResponse : BasePlacesResponse
{
    /// <summary>
    /// Contains an array of predictions, with information about the prediction.
    /// </summary>
    public virtual IEnumerable<Prediction> Predictions { get; set; }
}