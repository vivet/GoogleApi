using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Common.Enums;

/// <summary>
/// Units.
/// </summary>
public enum Units
{
    /// <summary>
    /// Metric (default) returns distances in kilometers and meters.
    /// </summary>
    [EnumMember(Value = "METRIC")]
    Metric,

    /// <summary>
    /// Imperial returns distances in miles and feet.
    /// </summary>
    [EnumMember(Value = "IMPERIAL")]
    Imperial
}