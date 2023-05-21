using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.AerialView.Common.Enums;

/// <summary>
/// State.
/// The different states a video can be in.
/// </summary>
public enum State
{
    /// <summary>
    /// Default value.This value is unused.
    /// </summary>
    [EnumMember(Value = "STATE_UNSPECIFIED")]
    State_Unspecified,

    /// <summary>
    /// The video is currently processing.
    /// </summary>
    [EnumMember(Value = "PROCESSING")]
    Processing,

    /// <summary>
    /// The video has finished rendering, and can be viewed through videos.getVideo.
    /// </summary>
    [EnumMember(Value = "ACTIVE")]
    Active,

    /// <summary>
    /// The video has failed to render.
    /// </summary>
    [EnumMember(Value = "FAILED")]
    Failed
}