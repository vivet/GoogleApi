namespace GoogleApi.Entities.PlacesNew.AutoComplete.Response;

/// <summary>
/// An Autocomplete suggestion result.
/// </summary>
public class Suggestion
{
    /// <summary>
    /// A prediction for a Place.
    /// </summary>
    public virtual PlacePrediction PlacePrediction { get; set; }

    /// <summary>
    /// A prediction for a query.
    /// </summary>
    public virtual QueryPrediction QueryPrediction { get; set; }
}