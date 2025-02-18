using System.Collections.Generic;
using GoogleApi.Entities.Maps.AerialView.Common;
using GoogleApi.Entities.Maps.AerialView.Common.Enums;

namespace GoogleApi.Entities.Maps.AerialView.GetVideo.Response;

/// <summary>
/// Get Video Response.
/// </summary>
public class GetVideoResponse : BaseResponseX
{
    /// <summary>
    /// Uris.
    /// A mapping of media types to their URIs.
    /// This field is only included for ACTIVE videos. The key is an enum value from MediaFormat.
    /// An object containing a list of "key": value pairs.Example: { "name": "wrench", "mass": "1.3kg", "count": "3" }.
    /// </summary>
    public virtual IDictionary<string, Uris> Uris { get; set; }

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