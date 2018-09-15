namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Safe Search.
    /// </summary>
    public enum SafeSearch
    {
        /// <summary>
        /// None.
        /// YouTube will not filter the search result set.
        /// </summary>
        None,

        /// <summary>
        /// Moderate.
        /// YouTube will filter some content from search results and, at the least, will filter content that is restricted in your locale.
        /// Based on their content, search results could be removed from search results or demoted in search results. This is the default parameter value.
        /// </summary>
        Moderate,

        /// <summary>
        /// YouTube will try to exclude all restricted content from the search result set.
        /// Based on their content, search results could be removed from search results or demoted in search results.
        /// </summary>
        Strict
    }
}