namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Fare.
/// </summary>
public class Fare
{
    /// <summary>
    ///  An ISO 4217 currency code indicating the currency that the amount is expressed in.
    /// </summary>
    public virtual string Currency { get; set; }

    /// <summary>
    /// The total fare amount, in the currency.
    /// </summary>
    public double? Value { get; set; }

    /// <summary>
    /// The total fare amount, formatted in the requested language.
    /// </summary>
    public virtual string Text { get; set; }
}