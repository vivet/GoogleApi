using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response.Enums
{
    /// <summary>
    /// Maneuver Action.
    /// </summary>
    public enum ManeuverAction
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        None,

        /// <summary>
        /// Turn_Slight_Left.
        /// </summary>
        [EnumMember(Value = "turn-slight-left")]
        Turn_Slight_Left,

        /// <summary>
        /// Sharp_Left.
        /// </summary>
        [EnumMember(Value = "turn-sharp-left")]
        Sharp_Left,

        /// <summary>
        /// Uturn_Left.
        /// </summary>
        [EnumMember(Value = "uturn-left")]
        Uturn_Left,

        /// <summary>
        /// Turn_Left.
        /// </summary>
        [EnumMember(Value = "turn-left")]
        Turn_Left,

        /// <summary>
        /// Turn_Slight_Right.
        /// </summary>
        [EnumMember(Value = "turn-slight-right")]
        Turn_Slight_Right,

        /// <summary>
        /// Turn_Sharp_Right.
        /// </summary>
        [EnumMember(Value = "turn-sharp-right")]
        Turn_Sharp_Right,

        /// <summary>
        /// Uturn_Right.
        /// </summary>
        [EnumMember(Value = "uturn-right")]
        Uturn_Right,

        /// <summary>
        /// Turn_Right.
        /// </summary>
        [EnumMember(Value = "turn-right")]
        Turn_Right,

        /// <summary>
        /// Straight.
        /// </summary>
        [EnumMember(Value = "straight")]
        Straight,

        /// <summary>
        /// Ramp_Left.
        /// </summary>
        [EnumMember(Value = "ramp-left")]
        Ramp_Left,

        /// <summary>
        /// Ramp_Right.
        /// </summary>
        [EnumMember(Value = "ramp-right")]
        Ramp_Right,

        /// <summary>
        /// Merge.
        /// </summary>
        [EnumMember(Value = "merge")]
        Merge,

        /// <summary>
        /// Fork_Left.
        /// </summary>
        [EnumMember(Value = "fork-left")]
        Fork_Left,

        /// <summary>
        /// Fork_Right.
        /// </summary>
        [EnumMember(Value = "fork-right")]
        Fork_Right,

        /// <summary>
        /// Ferry.
        /// </summary>
        [EnumMember(Value = "ferry")]
        Ferry,

        /// <summary>
        /// Ferry_Train.
        /// </summary>
        [EnumMember(Value = "ferry-train")]
        Ferry_Train,

        /// <summary>
        /// Roundabout_Left.
        /// </summary>
        [EnumMember(Value = "roundabout-left")]
        Roundabout_Left,

        /// <summary>
        /// Roundabout_Right.
        /// </summary>
        [EnumMember(Value = "roundabout-right")]
        Roundabout_Right,

        /// <summary>
        /// Keep_Left.
        /// </summary>
        [EnumMember(Value = "keep-left")]
        Keep_Left,

        /// <summary>
        /// Keep_Right.
        /// </summary>
        [EnumMember(Value = "keep-right")]
        Keep_Right
    }
}