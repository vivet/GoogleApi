using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Containment.
/// </summary>
public enum Containment
{
    /// <summary>
    /// Near.
    /// The default relationship when none of the following applies.
    /// </summary>
    [EnumMember(Value = "CONTAINMENT_UNSPECIFIED")]
    Unspecified,

    /// <summary>
    /// Near.
    /// The default relationship when none of the following applies.
    /// </summary>
    [EnumMember(Value = "NEAR")]
    Near,

    /// <summary>
    /// Within.
    /// The input coordinate is close to the center of the area.
    /// </summary>
    [EnumMember(Value = "WITHIN")]
    Within,

    /// <summary>
    /// Outskirts.
    /// The input coordinate is close to the edge of the area.
    /// </summary>
    [EnumMember(Value = "OUTSKIRTS")]
    Outskirts
}