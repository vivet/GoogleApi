namespace GoogleApi.Entities.Search.Common.Enums;

/// <summary>
/// Operator.
/// </summary>
public enum Operator
{
    /// <summary>
    /// The AND operator (.) returns results that are in the intersection of the collections to either side of the "." operator.
    /// This example removes all results originating from France or Italy:
    /// Example: cr= (-countryFR).(-countryIT)
    /// </summary>
    And,

    /// <summary>
    /// The OR operator (.) returns results that are in either the collection to the left or the collection to the right of the pipe("|") operator.
    /// This example returns all results that originate from France or Italy:
    /// cr= countryFR | countryIT
    /// </summary>
    Or
}