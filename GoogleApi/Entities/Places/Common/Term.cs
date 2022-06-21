using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Term.
/// </summary>
public class Term
{
    /// <summary>
    /// Containing the text of the term.
    /// </summary>
    [JsonProperty("value")]
    public virtual string Value { get; set; }

    /// <summary>
    /// Defining the start position of this term in the description, measured in Unicode characters.
    /// </summary>
    [JsonProperty("offset")]
    public virtual string Offset { get; set; }
}