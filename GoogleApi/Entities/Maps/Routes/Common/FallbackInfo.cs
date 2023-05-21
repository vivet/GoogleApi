using GoogleApi.Entities.Maps.Routes.Common.Enums;

namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
///Fallback Info.
/// Information related to how and why a fallback result was used.
/// If this field is set, then it means the server used a different routing mode from your preferred mode as fallback.
/// </summary>
public class FallbackInfo
{
    /// <summary>
    /// Routing Mode.
    /// Routing mode used for the response.
    /// If fallback was triggered, the mode may be different from routing preference set in the original client request.
    /// </summary>
    public virtual FallbackRoutingMode RoutingMode { get; set; }

    /// <summary>
    /// Reason.
    /// The reason why fallback response was used instead of the original response.
    /// This field is only populated when the fallback mode is triggered and the fallback response is returned.
    /// </summary>
    public virtual FallbackReason Reason { get; set; }
}