using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Search.Video.Common.Enums;

namespace GoogleApi.Entities.Search.Video.Videos.Request
{
    /// <summary>
    /// Video Search Request.
    /// </summary>
    public class VideoSearchRequest : BaseVideoSearchRequest
    {
        /// <summary>
        /// The channelId parameter indicates that the API response should only contain resources created by the channel.
        /// Note: Search results are constrained to a maximum of 500 videos if your request specifies a value for the channelId parameter and
        /// sets the type parameter value to video, but it does not also set one of the forContentOwner, forDeveloper, or forMine filters.
        /// </summary>
        public virtual string ChannelId { get; set; }

        /// <summary>
        /// The relatedToVideoId parameter retrieves a list of videos that are related to the video that the parameter value identifies.
        /// The parameter value must be set to a YouTube video ID and, if you are using this parameter, the type parameter must be set to video.
        /// NOTE, that if the relatedToVideoId parameter is set, the only other supported parameters are
        /// - part,
        /// - maxResults,
        /// - pageToken,
        /// - regionCode,
        /// - relevanceLanguage,
        /// - safeSearch,
        /// - type (which must be set to video),
        /// - and fields.
        /// </summary>
        public virtual string RelatedToVideoId { get; set; }

        /// <summary>
        /// The eventType parameter restricts a search to broadcast events.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual EventType? EventType { get; set; }

        /// <summary>
        /// The channelType parameter lets you restrict a search to a particular type of channel.
        /// </summary>
        public virtual ChannelType? ChannelType { get; set; }

        /// <summary>
        /// Options.
        /// Additional video options.
        /// </summary>
        public virtual VideoOptions Options { get; set; } = new VideoOptions();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public VideoSearchRequest()
        {
            this.SearchType = Search.Common.Enums.SearchType.Video;
        }

        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{T}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.ChannelId != null)
                parameters.Add("channelId", this.ChannelId);

            if (this.RelatedToVideoId != null)
                parameters.Add("relatedToVideoId", this.RelatedToVideoId);

            if (this.EventType.HasValue)
                parameters.Add("eventType", this.EventType.ToString().ToLower());
         
            if (this.ChannelType.HasValue)
                parameters.Add("channelType", this.ChannelType.ToString().ToLower());

            parameters.Add("videoCaption", this.Options.VideoCaption.ToString().ToLower());
            parameters.Add("videoDefinition", this.Options.VideoDefinition.ToString().ToLower());
            parameters.Add("videoDimension", this.Options.VideoDimension.ToString().ToLower());
            parameters.Add("videoDuration", this.Options.VideoDuration.ToString().ToLower());
            parameters.Add("videoEmbeddable", this.Options.VideoEmbeddable.ToString().ToLower());
            parameters.Add("videoLicense", this.Options.VideoLicense.ToString().ToLower());
            parameters.Add("videoSyndicated", this.Options.VideoSyndicated.ToString().ToLower());
            parameters.Add("videoType", this.Options.VideoType.ToString().ToLower());

            return parameters;
        }
    }
}