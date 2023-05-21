using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Common.Enums;

/// <summary>
/// Fallback Reason.
/// Reasons for using fallback response.
/// </summary>
public enum FallbackReason
{
    /// <summary>
    /// No fallback reason specified.
    /// </summary>
    [EnumMember(Value = "FALLBACK_REASON_UNSPECIFIED")]
    FallbackReasonUnspecified,

    /// <summary>
    /// A server error happened while calculating routes with your preferred routing mode,
    /// but we were able to return a result calculated by an alternative mode.
    /// </summary>
    [EnumMember(Value = "SERVER_ERROR")]
    ServerError,

    /// <summary>
    /// We were not able to finish the calculation with your preferred routing mode on time,
    /// but we were able to return a result calculated by an alternative mode.
    /// </summary>
    [EnumMember(Value = "LATENCY_EXCEEDED")]
    LatencyExceeded
}