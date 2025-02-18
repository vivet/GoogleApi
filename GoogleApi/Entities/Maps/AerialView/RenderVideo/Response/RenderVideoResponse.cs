using GoogleApi.Entities.Maps.AerialView.Common;
using GoogleApi.Entities.Maps.AerialView.Common.Enums;

namespace GoogleApi.Entities.Maps.AerialView.RenderVideo.Response;

/// <summary>
/// Render Video Response.
/// </summary>
public class RenderVideoResponse : BaseResponseX
{
    /// <summary>
    /// State.
    /// Current state of the render request.
    /// </summary>
    public virtual State State { get; set; } = State.State_Unspecified;

    /// <summary>
    /// Metadata.
    /// Contains the video's metadata, only set if the state is ACTIVE.
    /// </summary>
    public virtual VideoMetadata Metadata { get; set; }
}