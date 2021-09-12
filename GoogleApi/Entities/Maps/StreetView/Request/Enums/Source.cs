namespace GoogleApi.Entities.Maps.StreetView.Request.Enums
{
    /// <summary>
    /// Source
    /// </summary>
    public enum Source
    {
        /// <summary>
        /// default uses the default sources for Street View; searches are not limited to specific sources.
        /// </summary>
        Default,

        /// <summary>
        /// outdoor limits searches to outdoor collections.
        /// Indoor collections are not included in search results. Note that outdoor panoramas may not exist for the specified location.
        /// Also note that the search only returns panoramas where it's possible to determine whether they're indoors or outdoors.
        /// For example, PhotoSpheres are not returned because it's unknown whether they are indoors or outdoors.
        /// </summary>
        Outdoor
    }
}