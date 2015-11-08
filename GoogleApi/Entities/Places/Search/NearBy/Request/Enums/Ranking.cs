namespace GoogleApi.Entities.Places.Search.NearBy.Request.Enums
{
    /// <summary>
    /// Specifies the order in which results are listed for place searches.
    /// </summary>
    public enum Ranking
    {
        /// <summary>
        /// This option sorts results based on their importance. 
        /// Ranking will favor prominent places within the specified area. Prominence can be affected by a place's ranking in Google's index, global popularity, and other factors.
        /// </summary>
        PROMINENCE,
        /// <summary>
        /// This option biases search results in ascending order by their distance from the specified location. When distance is specified, one or more of keyword, name, or types is required
        /// </summary>
        DISTANCE,
    }
}