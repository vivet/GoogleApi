using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;

namespace GoogleApi.Entities.Maps.StaticMaps.Request
{
	/// <summary>
	/// Map Marker Icon.
	/// Rather than use Google's marker icons, you are free to use your own custom icons instead. 
	/// </summary>
	public class MapMarkerIcon
    {
        /// <summary>
        /// Rather than use Google's marker icons, you are free to use your own custom icons instead. 
        /// Custom icons are specified using the icon descriptor in the markers parameter. For example: markers=icon:URLofIcon|markerLocation.
        /// Specify the icon using a URL(which should be URL-encoded). You can use URLs created by URL-shortening services such as https://goo.gl. 
        /// Most URL-shortening services have the advantage of automatically encoding URLs.  You may specify an anchor point for the custom icon.
        /// Icon images may be in PNG, JPEG or GIF formats, though PNG is recommended. Icons may be up to 4096 pixels maximum size (64x64 for square images).
        /// </summary>
        public virtual string Url { get; set; }

	    /// <summary>
	    /// The anchor point sets how the icon is placed in relation to the specified markers locations.
	    /// By default, the anchor point of a custom icon is the bottom center of the icon image.
	    /// You can specify a different anchor point using the anchor descriptor in conjunction with your icon.
	    /// Set the anchor as an x, y point of the icon (such as 10,5), or as a predefined alignment using one of the following values: top, bottom, left, right, center, topleft, topright, bottomleft, or bottomright.For example:
	    /// markers= anchor:bottomright|icon:URLofIcon|markerLocation1|markerLocation2
	    /// </summary>
	    public virtual Anchor? Anchor { get; set; }
    }
}