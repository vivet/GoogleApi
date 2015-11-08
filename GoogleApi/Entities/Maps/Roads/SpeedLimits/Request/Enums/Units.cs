using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Request.Enums
{
    /// <summary>
    /// Speed Units
    /// </summary>
    [DataContract]
    public enum Units
    {
        /// <summary>
        /// Miles per hour.
        /// </summary>
        [EnumMember(Value = "MPH")]
        MPH,
        /// <summary>
        /// Kilometers per hour.
        /// </summary>
        [EnumMember(Value = "KPH")]
        KPH,
    }
}