using GoogleApi.Entities.Search.Video.Videos.Request.Enums;

namespace GoogleApi.Entities.Search.Video.Videos.Request
{
    /// <summary>
    /// Video Options.
    /// </summary>
    public class VideoOptions
    {
        /// <summary>
        /// The videoCategoryId parameter filters video search results based on their category.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual string VideoCategoryId { get; set; }

        /// <summary>
        /// The videoCaption parameter indicates whether the API should filter video search results based on whether they have captions.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoCaptionType VideoCaption { get; set; } = VideoCaptionType.Any;

        /// <summary>
        /// The videoDefinition parameter lets you restrict a search to only include either high definition (HD) or standard definition (SD) videos.
        /// HD videos are available for playback in at least 720p, though higher resolutions, like 1080p, might also be available.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoDefinitionType VideoDefinition { get; set; } = VideoDefinitionType.Any;

        /// <summary>
        /// The videoDimension parameter lets you restrict a search to only retrieve 2D or 3D videos.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoDimensionType VideoDimension { get; set; } = VideoDimensionType.Any;

        /// <summary>
        /// The videoDuration parameter filters video search results based on their duration.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoDurationType VideoDuration { get; set; } = VideoDurationType.Any;

        /// <summary>
        /// The videoEmbeddable parameter lets you to restrict a search to only videos that can be embedded into a webpage.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoEmbeddableType VideoEmbeddable { get; set; } = VideoEmbeddableType.Any;

        /// <summary>
        /// The videoLicense parameter filters search results to only include videos with a particular license.
        /// YouTube lets video uploaders choose to attach either the Creative Commons license or the standard YouTube license to each of their videos.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoLicenseType VideoLicense { get; set; } = VideoLicenseType.Any;

        /// <summary>
        /// The videoSyndicated parameter lets you to restrict a search to only videos that can be played outside youtube.com.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoSyndicatedType VideoSyndicated { get; set; } = VideoSyndicatedType.Any;

        /// <summary>
        /// The videoType parameter lets you restrict a search to a particular type of videos.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual VideoType VideoType { get; set; } = VideoType.Any;
    }
}