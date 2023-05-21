namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Term.
/// </summary>
public class Term
{
    /// <summary>
    /// Containing the text of the term.
    /// </summary>
    public virtual string Value { get; set; }

    /// <summary>
    /// Defining the start position of this term in the description, measured in Unicode characters.
    /// </summary>
    public virtual int? Offset { get; set; }
}