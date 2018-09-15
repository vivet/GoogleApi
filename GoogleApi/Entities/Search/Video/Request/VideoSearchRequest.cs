using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Search.Video.Request.Enums;
using GoogleApi.Entities.Search.Video.Response.Enums;
using GoogleApi.Entities.Search.Video.Response.Enums.Extensions;

namespace GoogleApi.Entities.Search.Video.Request
{


    /// <summary>
    /// Video Search Request.
    /// </summary>
    public class VideoSearchRequest : BaseSearchRequest
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/youtube/v3/search";

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public VideoSearchRequest()
        {
            this.SearchType = Common.Enums.SearchType.Video;
        }

        /// <summary>
        /// The part parameter specifies a comma-separated list of one or more search resource properties that the API response will include.
        /// </summary>
        public virtual PartType Part { get; set; } = PartType.Snippet;

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
        /// The channelId parameter indicates that the API response should only contain resources created by the channel.
        /// Note: Search results are constrained to a maximum of 500 videos if your request specifies a value for the channelId parameter and
        /// sets the type parameter value to video, but it does not also set one of the forContentOwner, forDeveloper, or forMine filters.
        /// </summary>
        public virtual string ChannelId { get; set; }

        /// <summary>
        /// The channelType parameter lets you restrict a search to a particular type of channel.
        /// </summary>
        public virtual ChannelType ChannelType { get; set; } = ChannelType.Any;

        /// <summary>
        /// The eventType parameter restricts a search to broadcast events.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public virtual EventType? EventType { get; set; }

        /// <summary>
        /// The location parameter, in conjunction with the locationRadius parameter, defines a circular geographic area and also restricts a search to videos that specify,
        /// in their metadata, a geographic location that falls within that area.
        /// The parameter value is a string that specifies latitude/longitude coordinates e.g. (37.42307,-122.08427).
        /// The location parameter value identifies the point at the center of the area.
        /// The locationRadius parameter specifies the maximum distance that the location associated with a video can be from that point for
        /// the video to still be included in the search results.  The API returns an error if your request specifies a value for the location parameter but does not
        /// also specify a value for the locationRadius parameter.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// The locationRadius parameter, in conjunction with the location parameter, defines a circular geographic area.
        /// The parameter value must be a floating point number followed by a measurement unit.Valid measurement units are m, km, ft, and mi. For example,
        /// valid parameter values include 1500m, 5km, 10000ft, and 0.75mi.
        /// The API does not support locationRadius parameter values larger than 1000 kilometers.
        /// Note: See the definition of the location parameter for more information.
        /// </summary>
        public virtual int? LocationRadiusInMeters { get; set; }

        /// <summary>
        /// The maxResults parameter specifies the maximum number of items that should be returned in the result set.
        /// Acceptable values are 0 to 50, inclusive.
        /// The default value is 5.
        /// </summary>
        public virtual int MaxResults { get; set; } = 5;

        /// <summary>
        /// This parameter can only be used in a properly authorized request.
        /// Note: This parameter is intended exclusively for YouTube content partners.
        /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user
        /// who is acting on behalf of the content owner specified in the parameter value.
        /// This parameter is intended for YouTube content partners that own and manage many different YouTube channels.
        /// It allows content owners to authenticate once and get access to all their video and channel data,
        /// without having to provide authentication credentials for each individual channel.
        /// The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
        /// </summary>
        public virtual string OnBehalfOfContentOwner { get; set; }

        /// <summary>
        /// The order parameter specifies the method that will be used to order resources in the API response.
        /// The default value is relevance.
        /// </summary>
        public virtual Order Order { get; set; } = Order.Relevance;
        
        /// <summary>
        /// The pageToken parameter identifies a specific page in the result set that should be returned.
        /// In an API response, the nextPageToken and prevPageToken properties identify other pages that could be retrieved.
        /// </summary>
        public virtual string PageToken { get; set; }

        /// <summary>
        /// The publishedAfter parameter indicates that the API response should only contain resources created at or after the specified time.
        /// The value is an RFC 3339 formatted date-time value(1970-01-01T00:00:00Z).
        /// </summary>
        public virtual DateTime? PublishedAfter { get; set; }

        /// <summary>
        /// The publishedBefore parameter indicates that the API response should only contain resources created before or at the specified time.
        /// The value is an RFC 3339 formatted date-time value(1970-01-01T00:00:00Z).
        /// </summary>
        public virtual DateTime? PublishedBefore { get; set; }

        /// <summary>
        /// The regionCode parameter instructs the API to return search results for videos that can be viewed in the specified country.
        /// The parameter value is an ISO 3166-1 alpha-2 country code.
        /// </summary>
        public virtual Country? Region { get; set; }

        /// <summary>
        /// The relevanceLanguage parameter instructs the API to return search results that are most relevant to the specified language.
        /// The parameter value is typically an ISO 639-1 two-letter language code.
        /// However, you should use the values zh-Hans for simplified Chinese and zh-Hant for traditional
        /// </summary>
        public virtual Language? RelevanceLanguage { get; set; }

        /// <summary>
        /// The safeSearch parameter indicates whether the search results should include restricted content
        /// as well as standard content.
        /// </summary>
        public virtual SafeSearch SafeSearch { get; set; } = SafeSearch.None;

        /// <summary>
        /// The topicId parameter indicates that the API response should only contain resources associated with the specified topic.
        /// </summary>
        public virtual string TopicId { get; set; }

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

        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{T}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            // TODO: Proper Validation, parameter inclusion and exclusion. 

            if (this.MaxResults <= 0 || this.MaxResults > 50)
                throw new ArgumentOutOfRangeException(nameof(this.MaxResults));

            parameters.Add("type", this.SearchType.ToString().ToLower());

            var parts = Enum.GetValues(typeof(PartType))
                .Cast<PartType>()
                .Where(x => this.Part.HasFlag(x))
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLower()},");

            parameters.Add("part", parts.EndsWith(",") ? parts.Substring(0, parts.Length - 1) : parts);

            if (this.RelatedToVideoId != null)
                parameters.Add("relatedToVideoId", this.RelatedToVideoId);

            if (this.ChannelId != null)
                parameters.Add("channelId", this.ChannelId);

            // TODO: parameters.Add("channelType", this.ChannelType.ToString().ToLower());

            if (this.EventType.HasValue)
                parameters.Add("eventType", this.EventType.ToString().ToLower());

            if (this.Location != null)
            {
                parameters.Add("location", this.Location.ToString());

                if (this.LocationRadiusInMeters.HasValue)
                    parameters.Add("locationRadius", $"{this.LocationRadiusInMeters}m");
            }

            parameters.Add("maxResults", this.MaxResults.ToString());

            if (this.OnBehalfOfContentOwner != null)
                parameters.Add("onBehalfOfContentOwner", this.OnBehalfOfContentOwner);

            parameters.Add("order", this.Order.ToString().ToLower());

            if (this.PageToken != null)
                parameters.Add("nextPageToken", this.PageToken);

            if (this.PublishedAfter.HasValue)
                parameters.Add("publishedAfter", this.PublishedAfter.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

            if (this.PublishedBefore.HasValue)
                parameters.Add("publishedBefore", this.PublishedBefore.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

            if (this.Region.HasValue)
                parameters.Add("regionCode", this.Region.Value.ToCode());

            if (this.RelevanceLanguage.HasValue)
                parameters.Add("relevanceLanguage", this.RelevanceLanguage.Value.ToCode());

            parameters.Add("safeSearch", this.SafeSearch.ToString().ToLower());

            if (this.TopicId != null)
                parameters.Add("topicId", this.TopicId);

            parameters.Add("videoCaption", this.VideoCaption.ToString().ToLower());
            parameters.Add("videoDefinition", this.VideoDefinition.ToString().ToLower());
            parameters.Add("videoDimension", this.VideoDimension.ToString().ToLower());
            parameters.Add("videoDuration", this.VideoDuration.ToString().ToLower());
            parameters.Add("videoEmbeddable", this.VideoEmbeddable.ToString().ToLower());
            parameters.Add("videoLicense", this.VideoLicense.ToString().ToLower());
            parameters.Add("videoSyndicated", this.VideoSyndicated.ToString().ToLower());
            parameters.Add("videoType", this.VideoType.ToString().ToLower());

            return parameters;
        }
    }
}