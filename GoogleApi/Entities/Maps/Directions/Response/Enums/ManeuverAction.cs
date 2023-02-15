using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Maps.Directions.Response.Enums;

/// <summary>
/// Maneuver Action.
/// </summary>
[JsonConverter(typeof(EnumConverter<ManeuverAction>))]
public enum ManeuverAction
{
    /// <summary>
    /// None.
    /// </summary>
    None,

    /// <summary>
    /// Turn Slight Left.
    /// </summary>
    [EnumMember(Value = "turn-slight-left")]
    Turn_Slight_Left,

    /// <summary>
    /// Sharp Left.
    /// </summary>
    [EnumMember(Value = "turn-sharp-left")]
    Sharp_Left,

    /// <summary>
    /// Uturn Left.
    /// </summary>
    [EnumMember(Value = "uturn-left")]
    Uturn_Left,

    /// <summary>
    /// Turn Left.
    /// </summary>
    [EnumMember(Value = "turn-left")]
    Turn_Left,

    /// <summary>
    /// Turn Slight Right.
    /// </summary>
    [EnumMember(Value = "turn-slight-right")]
    Turn_Slight_Right,

    /// <summary>
    /// Turn Sharp Right.
    /// </summary>
    [EnumMember(Value = "turn-sharp-right")]
    Turn_Sharp_Right,

    /// <summary>
    /// Uturn Right.
    /// </summary>
    [EnumMember(Value = "uturn-right")]
    Uturn_Right,

    /// <summary>
    /// Turn Right.
    /// </summary>
    [EnumMember(Value = "turn-right")]
    Turn_Right,

    /// <summary>
    /// Straight.
    /// </summary>
    [EnumMember(Value = "straight")]
    Straight,

    /// <summary>
    /// Ramp.
    /// </summary>
    [EnumMember(Value = "ramp")]
    Ramp,

    /// <summary>
    /// Ramp Left.
    /// </summary>
    [EnumMember(Value = "ramp-left")]
    Ramp_Left,

    /// <summary>
    /// Ramp Right.
    /// </summary>
    [EnumMember(Value = "ramp-right")]
    Ramp_Right,

    /// <summary>
    /// Merge.
    /// </summary>
    [EnumMember(Value = "merge")]
    Merge,

    /// <summary>
    /// Fork Left.
    /// </summary>
    [EnumMember(Value = "fork-left")]
    Fork_Left,

    /// <summary>
    /// Fork Right.
    /// </summary>
    [EnumMember(Value = "fork-right")]
    Fork_Right,

    /// <summary>
    /// Ferry.
    /// </summary>
    [EnumMember(Value = "ferry")]
    Ferry,

    /// <summary>
    /// Ferry Train.
    /// </summary>
    [EnumMember(Value = "ferry-train")]
    Ferry_Train,

    /// <summary>
    /// Roundabout Left.
    /// </summary>
    [EnumMember(Value = "roundabout-left")]
    Roundabout_Left,

    /// <summary>
    /// Roundabout Right.
    /// </summary>
    [EnumMember(Value = "roundabout-right")]
    Roundabout_Right,

    /// <summary>
    /// Keep Left.
    /// </summary>
    [EnumMember(Value = "keep-left")]
    Keep_Left,

    /// <summary>
    /// Keep Right.
    /// </summary>
    [EnumMember(Value = "keep-right")]
    Keep_Right
}