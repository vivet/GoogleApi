namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Video License Type.
    /// </summary>
    public enum VideoLicenseType
    {
        /// <summary>
        /// Any.
        /// Return all videos, regardless of which license they have, that match the query parameters.
        /// This is the default value.
        /// </summary>
        Any,

        /// <summary>
        /// Creative Common.
        /// Only return videos that have a Creative Commons license.Users can reuse videos with this license in other videos that they create.Learn more.
        /// </summary>
        CreativeCommon,

        /// <summary>
        /// YouTube.
        /// Only return videos that have the standard YouTube license.
        /// </summary>
        YouTube
    }
}