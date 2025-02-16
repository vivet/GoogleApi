using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.AutoComplete.Response;

/// <summary>
/// When the Places service returns JSON results from a search, it places them within a predictions array.
/// </summary>
public class PlacesNewAutoCompleteResponse : BaseResponseX
{
    /// <summary>
    /// Contains a list of suggestions, ordered in descending order of relevance.
    /// </summary>
    public virtual IEnumerable<Suggestion> Suggestions { get; set; }
}