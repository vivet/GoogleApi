namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Action Type.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Contains information about an action that a particular user has taken on the YouTube site.
        /// User actions that are reported in activity feeds include rating a video, sharing a video, marking a video as a favorite,
        /// and posting a channel bulletin, among others.
        /// </summary>
        Activity,

        /// <summary>
        /// Contains information about a single YouTube channel.
        /// </summary>
        Channel,

        /// <summary>
        /// Identifies the URL to use to set a newly uploaded image as the banner image for a channel.
        /// </summary>
        ChannelBanner,

        /// <summary>
        /// Contains information about a set of videos that a channel has chosen to feature.For example, a section could feature a channel's latest uploads,
        /// most popular uploads, or videos from one or more playlists.
        /// </summary>
        ChannelSection,

        /// <summary>
        /// Identifies a category that YouTube associates with channels based on their content or other indicators,
        /// such as popularity.Guide categories seek to organize channels in a way that makes it easier for YouTube users to find the content they're looking for.
        /// While channels could be associated with one or more guide categories, they are not guaranteed to be in any guide categories.
        /// </summary>
        GuideCategory,

        /// <summary>
        /// Identifies an application language that the YouTube website supports.
        /// The application language can also be referred to as a UI language.
        /// </summary>
        I18nLanguage,

        /// <summary>
        /// Identifies a geographic area that a YouTube user can select as the preferred content region.
        /// The content region can also be referred to as a content locale.
        /// </summary>
        I18nRegion,

        /// <summary>
        /// Represents a single YouTube playlist.
        /// A playlist is a collection of videos that can be viewed sequentially and shared with other users.
        /// </summary>
        Playlist,

        /// <summary>
        /// Identifies a resource, such as a video, that is part of a playlist.
        /// The playlistItem resource also contains details that explain how the included resource is used in the playlist.
        /// </summary>
        PlaylistItem,

        /// <summary>
        /// Contains information about a YouTube video, channel, or playlist that matches the search parameters specified in an API request.
        /// While a search result points to a uniquely identifiable resource, like a video, it does not have its own persistent data.
        /// </summary>
        Search_Result,

        /// <summary>
        /// Contains information about a YouTube user subscription.
        /// A subscription notifies a user when new videos are added to a channel or when another user takes one of several actions on YouTube,
        /// such as uploading a video, rating a video, or commenting on a video.
        /// </summary>
        Subscription,

        /// <summary>
        /// Identifies thumbnail images associated with a resource.
        /// </summary>
        Thumbnail,

        /// <summary>
        /// Represents a single YouTube video.
        /// </summary>
        Video,

        /// <summary>
        /// Identifies a category that has been or could be associated with uploaded videos.
        /// </summary>
        VideoCategory,

        /// <summary>
        /// Identifies an image that displays during playbacks of a specified channel's videos.
        /// The channel owner can also specify a target channel to which the image links as well as timing details that determine
        /// when the watermark appears during video playbacks and then length of time it is visible.
        /// </summary>
        Watermark
    }
}