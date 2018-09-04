namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Operation Type.
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// Retrieves (GET) a list of zero or more resources.
        /// </summary>
        List,

        /// <summary>
        /// Creates(POST) a new resource.
        /// </summary>
        Insert,

        /// <summary>
        /// Modifies(PUT) an existing resource to reflect data in your request.
        /// </summary>
        Update,

        /// <summary>
        /// Removes (DELETE) a specific resource.
        /// </summary>
        Delete
    }
}