using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

/// <summary>
/// Maneuver.
/// A set of values that specify the navigation action to take for the current step (e.g., turn left, merge, straight, etc.).
/// </summary>
public enum Maneuver
{
    /// <summary>
    /// Not used.
    /// </summary>
    [EnumMember(Value = "MANEUVER_UNSPECIFIED")]
    ManeuverUnspecified,

    /// <summary>
    /// Turn slightly to the left.
    /// </summary>
    [EnumMember(Value = "TURN_SLIGHT_LEFT")]
    TurnSlightLeft,

    /// <summary>
    /// Turn sharply to the left.
    /// </summary>
    [EnumMember(Value = "TURN_SHARP_LEFT")]
    TurnSharpLeft,

    /// <summary>
    /// Make a left u-turn.
    /// </summary>
    [EnumMember(Value = "UTURN_LEFT")]
    UturnLeft,

    /// <summary>
    /// Turn left.
    /// </summary>
    [EnumMember(Value = "TURN_LEFT")]
    TurnLeft,

    /// <summary>
    /// Turn slightly to the right.
    /// </summary>
    [EnumMember(Value = "TURN_SLIGHT_RIGHT")]
    TurnSlightRight,

    /// <summary>
    /// Turn sharply to the right.
    /// </summary>
    [EnumMember(Value = "TURN_SHARP_RIGHT")]
    TurnSharpRight,

    /// <summary>
    /// Make a right u-turn.
    /// </summary>
    [EnumMember(Value = "UTURN_RIGHT")]
    UturnRight,

    /// <summary>
    /// Turn right.
    /// </summary>
    [EnumMember(Value = "TURN_RIGHT")]
    TurnRight,

    /// <summary>
    /// Go straight.
    /// </summary>
    [EnumMember(Value = "STRAIGHT")]
    Straight,

    /// <summary>
    /// Take the left ramp.
    /// </summary>
    [EnumMember(Value = "RAMP_LEFT")]
    RampLeft,

    /// <summary>
    /// Take the right ramp.
    /// </summary>
    [EnumMember(Value = "RAMP_RIGHT")]
    RampRight,

    /// <summary>
    /// Merge into traffic.
    /// </summary>
    [EnumMember(Value = "MERGE")]
    Merge,

    /// <summary>
    /// Take the left fork.
    /// </summary>
    [EnumMember(Value = "FORK_LEFT")]
    ForkLeft,

    /// <summary>
    /// Take the right fork.
    /// </summary>
    [EnumMember(Value = "FORK_RIGHT")]
    ForkRight,

    /// <summary>
    /// Take the ferry.
    /// </summary>
    [EnumMember(Value = "FERRY")]
    Ferry,

    /// <summary>
    /// Take the train leading onto the ferry.
    /// </summary>
    [EnumMember(Value = "FERRY_TRAIN")]
    FerryTrain,

    /// <summary>
    /// Turn left at the roundabout.
    /// </summary>
    [EnumMember(Value = "ROUNDABOUT_LEFT")]
    RoundaboutLeft,

    /// <summary>
    /// Turn right at the roundabout.
    /// </summary>
    [EnumMember(Value = "ROUNDABOUT_RIGHT")]
    RoundaboutRight,
}