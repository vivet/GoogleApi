using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// The price range associated with a Place. endPrice could be unset,
/// which indicates a range without upper bound (e.g. "More than $100").
/// </summary>
public class PriceRange
{
    /// <summary>
    /// The low end of the price range (inclusive).
    /// Price should be at or above this amount
    /// </summary>
    public virtual Money StartPrice { get; set; }

    /// <summary>
    /// The high end of the price range (exclusive).
    /// Price should be lower than this amount.
    /// </summary>
    public virtual Money EndPrice { get; set; }
}