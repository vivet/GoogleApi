using System;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Maps.AerialView.Common;

/// <summary>
/// Video Metadata.
/// Contains metadata about a video, such as its videoId and duration.
/// </summary>
public class VideoMetadata
{
    /// <summary>
    /// Video Id.
    /// An ID for the video, and the recommended way to retrieve a video.
    /// </summary>
    public virtual string VideoId { get; set; }

    /// <summary>
    /// Capture Date
    /// The date at which the imagery used in the video was captured. This will be at a month-level granularity.
    /// </summary>
    public virtual Date CaptureDate { get; set; }

    /// <summary>
    /// Duration.
    /// The length of the video.
    /// A duration in seconds with up to nine fractional digits, ending with 's'. Example: "3.5s".
    /// </summary>
    [JsonConverter(typeof(StringSecondsTimeSpanJsonConverter))]
    public virtual TimeSpan? Duration { get; set; }
}