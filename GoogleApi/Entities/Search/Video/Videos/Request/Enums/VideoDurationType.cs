namespace GoogleApi.Entities.Search.Video.Videos.Request.Enums
{
    /// <summary>
    /// Video Duration Type.
    /// </summary>
    public enum VideoDurationType
    {
        /// <summary>
        /// Any.
        /// Do not filter video search results based on their duration.
        /// This is the default value.
        /// </summary>
        Any,

        /// <summary>
        /// Short.
        /// Only include videos that are less than four minutes long.
        /// </summary>
        Short,

        /// <summary>
        /// Medium.
        /// Only include videos that are between four and 20 minutes long (inclusive).
        /// </summary>
        Medium,

        /// <summary>
        /// Long.
        /// Only include videos longer than 20 minutes.
        /// </summary>
        Long
    }
}