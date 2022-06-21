using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Roads.Common.Enums;

/// <summary>
/// Speed Units.
/// </summary>
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