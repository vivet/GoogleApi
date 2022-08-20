using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Maps.Roads.Common.Enums;

/// <summary>
/// Speed Units.
/// </summary>
[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum Units
{
    /// <summary>
    /// Miles per hour.
    /// </summary>
    [EnumMember(Value = "MPH")]
    Mph,

    /// <summary>
    /// Kilometers per hour.
    /// </summary>
    [EnumMember(Value = "KPH")]
    Kph
}