namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Video Embeddable Type.
    /// </summary>
    public enum VideoEmbeddableType
    {
        /// <summary>
        /// Any.
        /// Return all videos, syndicated or not.
        /// This is the default value.
        /// </summary>
        Any,

        /// <summary>
        /// True.
        /// Only retrieve syndicated videos.
        /// </summary>
        True
    }
}