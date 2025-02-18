using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Common.Enums;

/// <summary>
/// Specifies the order in which results are listed for place searches.
/// </summary>
public enum PriceLevel
{
    /// <summary>
    /// Unspecified.
    /// </summary>
    [EnumMember(Value = "PRICE_LEVEL_UNSPECIFIED")]
    Unspecified,

    /// <summary>
    /// Free.
    /// </summary>
    [EnumMember(Value = "PRICE_LEVEL_FREE")]
    Free,

    /// <summary>
    /// Inexpensive.
    /// </summary>
    [EnumMember(Value = "PRICE_LEVEL_INEXPENSIVE")]
    Inexpensive,

    /// <summary>
    /// Moderate.
    /// </summary>
    [EnumMember(Value = "PRICE_LEVEL_MODERATE")]
    Moderate,

    /// <summary>
    /// Expensive.
    /// </summary>
    [EnumMember(Value = "PRICE_LEVEL_EXPENSIVE")]
    Expensive,

    /// <summary>
    /// Very Expensive.
    /// </summary>
    [EnumMember(Value = "PRICE_LEVEL_VERY_EXPENSIVE")]
    VeryExpensive
}