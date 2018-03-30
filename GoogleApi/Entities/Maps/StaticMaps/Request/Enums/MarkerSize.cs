namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums
{
    /// <summary>
    /// Specifies the size of marker from the set {tiny, mid, small}. 
    /// If no size parameter is set, the marker will appear in its default (normal) size.
    /// </summary>
    public enum MarkerSize
    {
        /// <summary>
        /// Normal (default).
        /// </summary>
        Normal,

        /// <summary>
        /// Tiny.
        /// </summary>
        Tiny,
        
        /// <summary>
        /// Mid.
        /// </summary>
        Mid,

        /// <summary>
        /// Small.
        /// </summary>
        Small
    }
}