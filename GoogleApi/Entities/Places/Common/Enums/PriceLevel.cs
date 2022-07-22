using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Places.Common.Enums;

/// <summary>
/// Specifies the order in which results are listed for place searches.
/// </summary>
[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum PriceLevel
{
    /// <summary>
    /// Free.
    /// </summary>
    [EnumMember(Value = "0")]
    Free = 0,

    /// <summary>
    /// Inexpensive.
    /// </summary>
    [EnumMember(Value = "1")]
    Inexpensive = 1,

    /// <summary>
    /// Moderate.
    /// </summary>
    [EnumMember(Value = "2")]
    Moderate = 2,

    /// <summary>
    /// Expensive.
    /// </summary>
    [EnumMember(Value = "3")]
    Expensive = 3,

    /// <summary>
    /// Very Expensive.
    /// </summary>
    [EnumMember(Value = "4")]
    VeryExpensive = 4
}