using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums.Extensions;

namespace GoogleApi.Entities.Maps.StaticMaps.Request
{
    /// <summary>
	/// Static Map Request.
	/// The Google Static Maps API lets you embed a Google Maps image on your web page without requiring JavaScript or any dynamic page loading. 
	/// The Google Static Maps API service creates your map based on URL parameters sent through a standard HTTP request and returns the map as an image you can 
	/// display on your web page.
	/// </summary>
	public class StaticMapsRequest : BaseRequest
	{
        /// <inheritdoc />
        protected internal override string BaseUrl { get; } = "maps.googleapis.com/maps/api/staticmap";

		/// <summary>
		/// center (required if markers not present) defines the center of the map, equidistant from all edges of the map. 
		/// This parameter takes a location as either a comma-separated {latitude,longitude} pair (e.g. "40.714728,-73.998672") or a string address (e.g. "city hall, new york, ny") 
		/// identifying a unique location on the face of the earth. For more information, see Locations below.
		/// </summary>
		public virtual Location Center { get; set; }

	    /// <summary>
	    /// Zoom (required if markers not present) defines the zoom level of the map, which determines the magnification level of the map. 
	    /// This parameter takes a numerical value corresponding to the zoom level of the region desired. For more information, see zoom levels below.
	    /// Maps on Google Maps have an integer 'zoom level' which defines the resolution of the current view. 
	    /// Zoom levels between 0 (the lowest zoom level, in which the entire world can be seen on one map) and 21+ (down to streets and individual buildings) 
	    /// are possible within the default roadmap view. Building outlines, where available, appear on the map around zoom level 17. 
	    /// This value differs from area to area and can change over time as the data evolves.
	    /// Google Maps sets zoom level 0 to encompass the entire earth.Each succeeding zoom level doubles the precision in both horizontal and vertical dimensions.
	    /// Note: not all zoom levels appear at all locations on the earth. 
	    /// Zoom levels vary depending on location, as data in some parts of the globe is more granular than in other locations.
	    ///	If you send a request for a zoom level at which no map tiles are available, the Google Static Maps API will return a map showing the maximum zoom level available 
	    /// at that location. The following list shows the approximate level of detail you can expect to see at each zoom level:
	    /// - 1: World
	    /// - 5: Landmass/continent
	    /// - 10: City
	    /// - 15: Streets
	    /// - 20: Buildings
	    /// </summary>
	    public virtual byte? ZoomLevel { get; set; }

		/// <summary>
		/// Size (required) defines the rectangular dimensions of the map image. 
		/// This parameter takes a string of the form {horizontal_value}x{vertical_value}. For example, 500x400 defines a map 500 pixels wide by 400 pixels high. 
		/// Maps smaller than 180 pixels in width will display a reduced-size Google logo. 
		/// This parameter is affected by the scale parameter, described below; the final output size is the product of the size and scale values.
		/// </summary>
		public virtual MapSize Size { get; set; } = new MapSize(640, 640);

	    /// <summary>
	    /// Defines the type of map to construct. There are several possible
	    /// maptype values, including roadmap, satellite, hybrid, and terrain. (optional)
	    /// </summary>
	    /// <remarks>http://code.google.com/apis/maps/documentation/staticmaps/#MapTypes</remarks>
	    public virtual MapType? Type { get; set; }

	    /// <summary>
	    /// Scale (optional) affects the number of pixels that are returned. scale=2 returns twice as many pixels as scale=1 while retaining the same coverage area and 
	    /// level of detail (i.e. the contents of the map don't change). This is useful when developing for high-resolution displays, or when generating a map for printing. 
	    /// The default value is 1. Accepted values are 2 and 4 (4 is only available to Google Maps APIs Premium Plan customers.) 
	    /// See Scale Values for more information: https://developers.google.com/maps/documentation/static-maps/intro#scale_values
	    /// </summary>
	    public virtual MapScale? Scale { get; set; }

        /// <summary>
        /// Format (optional) defines the format of the resulting image. By default, the Google Static Maps API creates PNG images. 
        /// There are several possible formats including GIF, JPEG and PNG types. Which format you use depends on how you intend to present the image. 
        /// JPEG typically provides greater compression, while GIF and PNG provide greater detail. For more information, see Image Formats.
        /// greater compression, while GIF and PNG provide greater detail. (optional)
        /// </summary>
        public virtual ImageFormat? Format { get; set; }

	    /// <summary>
	    /// Language (optional) defines the language to use for display of labels on map tiles. 
	    /// Note that this parameter is only supported for some country tiles; if the specific language requested is not supported for the tile set, 
	    /// then the default language for that tileset will be used.
	    /// </summary>
	    public virtual Language? Language { get; set; }

        /// <summary>
        /// region (optional) defines the appropriate borders to display, based on geo-political sensitivities. 
        /// Accepts a region code specified as a two-character ccTLD ('top-level domain') value
        /// </summary>
        public virtual string Region { get; set; }

		/// <summary>
		/// Paths (optional) defines a single path of two or more connected points to overlay on the image at specified locations. 
		/// This parameter takes a string of point definitions separated by the pipe character (|), or an encoded polyline using the enc: prefix within 
		/// the location declaration of the path. You may supply additional paths by adding additional path parameters. 
		/// Note that if you supply a path for a map, you do not need to specify the (normally required) center and zoom parameters. 
		/// For more information, see Google Static Maps API Paths below. https://developers.google.com/maps/documentation/static-maps/intro#Paths
		/// </summary>
		public virtual IEnumerable<MapPath> Paths { get; set; } = new List<MapPath>();

	    /// <summary>
	    /// Style (optional) defines a custom style to alter the presentation of specific features (roads, parks, and other features) of the map. 
	    /// This parameter takes features and element arguments identifying the features to style, and a set of style operations to apply to the selected features.
	    /// You can supply multiple styles by adding additional style parameters.
	    /// For more information, see the guide to styled maps.
	    /// </summary>
	    public virtual IEnumerable<MapStyle> Styles { get; set; } = new List<MapStyle>();

        /// <summary>
        /// Visibles (optional) specifies one or more locations that should remain visible on the map, though no markers or other indicators will be displayed. 
        /// Use this parameter to ensure that certain features or map locations are shown on the Google Static Maps API.
        /// </summary>
        public virtual IEnumerable<Location> Visibles { get; set; } = new List<Location>();

        /// <summary>
        /// Markers (optional) define one or more markers to attach to the image at specified locations. 
        /// This parameter takes a single marker definition with parameters separated by the pipe character (|). 
        /// Multiple markers may be placed within the same markers parameter as long as they exhibit the same style; 
        /// you may add additional markers of differing styles by adding additional markers parameters. Note that if you supply markers for a map, 
        /// you do not need to specify the (normally required) center and zoom parameters. 
        /// For more information, see Google Static Maps API Markers below. https://developers.google.com/maps/documentation/static-maps/intro#Markers
        /// </summary>
        public virtual IEnumerable<MapMarker> Markers { get; set; } = new List<MapMarker>();

		/// <inheritdoc />
		public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
		{
		    var parameters = base.GetQueryStringParameters();

		    if (string.IsNullOrEmpty(this.Key))
		        throw new ArgumentException("Key is required");

            if (this.Center == null || !this.ZoomLevel.HasValue)
		    {
		        var hasMarkers = this.Markers.Any() && this.Markers.SelectMany(x => x.Locations).Any();
		        var hasPaths = this.Paths.Any() && this.Paths.SelectMany(x => x.Points).Any();
		        var hasVisible = this.Visibles.Any();

		        if (!hasMarkers && !hasPaths && !hasVisible)
		        {
                    if (this.Center == null)
    		            throw new ArgumentException("Center is required, unless Markers, Path or Visibles is defined");

                    if (!this.ZoomLevel.HasValue)
                        throw new ArgumentException("Zoom Level is required, unless Markers, Path or Visibles is defined");
                }
            }

            if (this.Center != null)
                parameters.Add("center", this.Center.ToString());

            if (this.ZoomLevel.HasValue)
                parameters.Add("zoom", this.ZoomLevel.ToString());

		    parameters.Add("size", $"{this.Size.Width}x{this.Size.Height}");

			if (this.Type.HasValue)
				parameters.Add("maptype", this.Type.ToString().ToLower());

			if (this.Scale.HasValue)
		        parameters.Add("scale", ((int)this.Scale.Value).ToString());

		    if (this.Format.HasValue)
		        parameters.Add("format", this.Format.Value.GetParameterName());

		    if (this.Language.HasValue)
		        parameters.Add("language", this.Language.Value.ToCode());

            if (this.Region != null)
    		    parameters.Add("region", this.Region);

			if (this.Paths.Any())
			{
				foreach (var path in this.Paths)
				{
					if (!path.Points.Any())
						continue;

					var color = path.Color != null ? $"color:{path.Color}|" : string.Empty;
					var fillColor = path.FillColor != null ? $"fillcolor:{path.Color}|" : string.Empty;
					var geodesic = path.Geodesic ? "geodesic|" : string.Empty;
					var points = path.Points.Aggregate(string.Empty, (x, y) => $"{x}{y.ToString()}|");

					parameters.Add("path", $"{color}{fillColor}{geodesic}{points}");
				}
			}

			if (this.Styles.Any())
			{
				foreach (var style in this.Styles)
				{
					parameters.Add("style", $"{style.Element}|{style.Feature}|{style.Style}");
				}
			}

			if (this.Visibles.Any())
			{
				var visibles = this.Visibles.Aggregate(string.Empty, (x, y) => $"{x}{y.ToString()}|");

				parameters.Add("path", $"{visibles}");
			}

			if (this.Markers.Any())
			{
				foreach (var marker in this.Markers)
				{
                    if (!marker.Locations.Any())
                        continue;

				    var isLabel = string.IsNullOrEmpty(marker.Label) && !(marker.Size == MarkerSize.Tiny || marker.Size == MarkerSize.Small);

                    var label = isLabel ? $"label:{marker.Label}|" : string.Empty;
				    var color = marker.Color.HasValue ? $"color:{marker.Color.ToString()}|" : string.Empty;
                    var size = marker.Size.HasValue ? $"size:{marker.Size.ToString().ToLower()}|" : string.Empty;
				    var iconUrl = marker.Icon?.Url != null ? $"icon:{marker.Icon.Url}|" : string.Empty;
				    var iconAnchor = marker.Icon?.Anchor != null ? $"anchor:{marker.Icon?.Anchor.ToString()}|" : string.Empty;
				    var locations = marker.Locations.Aggregate(string.Empty, (x, y) => $"{x}{y.ToString()}|");

                    parameters.Add("markers", $"{label}{color}{size}{iconUrl}{iconAnchor}{locations}");
				}
			}

			return parameters;
		}
    }
}
