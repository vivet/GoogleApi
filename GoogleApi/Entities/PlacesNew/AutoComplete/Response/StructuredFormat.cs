namespace GoogleApi.Entities.PlacesNew.AutoComplete.Response;

/// <summary>
/// Contains a breakdown of a Place or query prediction into main text and secondary text.
/// For Place predictions, the main text contains the specific name of the Place.For query predictions, the main text contains the query.
/// The secondary text contains additional disambiguating features (such as a city or region) to further identify the Place or refine the query..
/// </summary>
public class StructuredFormat
{
    /// <summary>
    /// Represents the name of the Place or query.
    /// </summary>
    public virtual FormattableText MainText { get; set; }

    /// <summary>
    /// Represents additional disambiguating features (such as a city or region) to further identify the Place or refine the query.
    /// </summary>
    public virtual FormattableText SecondaryText { get; set; }
}