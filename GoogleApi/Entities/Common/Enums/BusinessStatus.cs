using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Business Status.
/// </summary>
public enum BusinessStatus
{
    /// <summary>
    /// Operational.
    /// </summary>
    [EnumMember(Value = "OPERATIONAL")]
    Operational,

    /// <summary>
    /// Closed Temporarily.
    /// </summary>
    [EnumMember(Value = "CLOSED_TEMPORARILY")]
    Closed_Temporarily,

    /// <summary>
    /// Closed Permanently
    /// </summary>
    [EnumMember(Value = "CLOSED_PERMANENTLY")]
    Closed_Permanently,

    /// <summary>
    /// Future Opening.
    /// </summary>
    [EnumMember(Value = "FUTURE_OPENING")]
    Future_Opening
}