namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums
{
	/// <summary>
	/// Map Type.
	/// The Google Static Maps API creates maps in several formats, listed below.
	/// </summary>
	public enum MapType
    {
        /// <summary>
        /// roadmap (default) specifies a standard roadmap image, as is normally shown on the Google Maps website. 
        /// If no maptype value is specified, the Google Static Maps API serves roadmap tiles by default.
        /// </summary>
        Roadmap,

        /// <summary>
        /// Satellite specifies a satellite image.
        /// </summary>
        Satellite,

        /// <summary>
        /// Hybrid specifies a hybrid of the satellite and roadmap image, showing a transparent layer of major streets and place names on the satellite image.
        /// </summary>
        Hybrid,

        /// <summary>
        /// Terrain specifies a physical relief map image, showing terrain and vegetation.
        /// </summary>
        Terrain
    }
}