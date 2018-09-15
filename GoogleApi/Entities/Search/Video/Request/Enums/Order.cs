namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Order.
    /// </summary>
    public enum Order
    {
        /// <summary>
        /// Resources are sorted in reverse chronological order based on the date they were created.
        /// </summary>
        Date,

        /// <summary>
        /// Resources are sorted from highest to lowest rating.
        /// </summary>
        Rating,

        /// <summary>
        /// Resources are sorted based on their relevance to the search query.This is the default value for this parameter.
        /// </summary>
        Relevance,

        /// <summary>
        /// Resources are sorted alphabetically by title..
        /// </summary>
        Title,

        /// <summary>
        /// Channels are sorted in descending order of their number of uploaded videos.
        /// </summary>
        VideoCount,

        /// <summary>
        /// Resources are sorted from highest to lowest number of views. For live broadcasts, videos are sorted by number of concurrent viewers while the broadcasts are ongoing.
        /// </summary>
        ViewCount 
    }
}