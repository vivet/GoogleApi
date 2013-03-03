using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Elevation.Request
{
	/// <summary>
	/// The Elevation API provides elevation data for all locations on the surface of the earth, including depth locations on the ocean floor (which return negative values). In those cases where Google does not possess exact elevation measurements at the precise location you request, the service will interpolate and return an averaged value using the four nearest locations.
	/// With the Elevation API, you can develop hiking and biking applications, mobile positioning applications, or low resolution surveying applications.
	/// You access the Elevation API through an HTTP interface Users of the Google JavaScript API V3 may also access this API directly by using the ElevationService() object. (See Elevation Service for more information.)
	/// The Elevation API is a new service; we encourage you to join the Maps API discussion group to give us feedback.
	/// </summary>
	public class ElevationRequest : SignableRequest
	{
		protected internal override string BaseUrl
		{
			get
			{
				return base.BaseUrl + "elevation/";
			}
		}
		
        /// <summary>
		/// locations (required) defines the location(s) on the earth from which to return elevation data. This parameter takes either a single location as a comma-separated {latitude,longitude} pair (e.g. "40.714728,-73.998672") or multiple latitude/longitude pairs passed as an array or as an encoded polyline. For more information, see Specifying Locations below.
		/// </summary>
		public IEnumerable<Location> Locations { get; set; }

		/// <summary>
		/// Sampled path requests are indicated through use of the path and samples parameters, indicating a request for elevation data along a path at specified intervals. As with positional requests using the locations parameter, the path parameter specifies a set of latitude and longitude values. Unlike a positional request, however, the path specifies an ordered set of vertices. Rather than return elevation data only at the vertices, path requests are sampled along the length of the path, based on the number of samples specified (inclusive of the endpoints).
        /// The path parameter may take either of the following arguments:
        /// An array of two or more comma-separated coordinate text strings separated using the pipe ('|') character: path=40.714728,-73.998672|-34.397,150.644
        /// Encoded coordinates using the Encoded Polyline Algorithm: path=enc:gfo}EtohhUxD@bAxJmGF
        /// Latitude and longitude coordinate strings are defined using numerals within a comma-separated text string. For example, "40.714728,-73.998672|-34.397, 150.644" is a valid path value. Latitude and longitude values must correspond to a valid location on the face of the earth. Latitudes can take any value between -90 and 90 while longitude values can take any value between -180 and 180. If you specify an invalid latitude or longitude value, your request will be rejected as a bad request.
        /// You may pass any number of multiple coordinates within an array or encoded polyline, as long as you don't exceed the service quotas, while still constructing a valid URL. Note that when passing multiple coordinates, the accuracy of any returned data may be of lower resolution than when requesting data for a single coordinate
		/// </summary>
		public IEnumerable<Location> Path { get; set; }

		protected override QueryStringParametersList GetQueryStringParameters()
		{
            if ((this.Locations == null) == (this.Path == null))
				throw new ArgumentException("Either Locations or Path must be specified, and both cannot be specified.");

			var _parameters = base.GetQueryStringParameters();
            _parameters.Add(this.Locations != null ? "locations" : "path", string.Join("|", this.Locations ?? (this.Path ?? new[] { new Location(0, 0) })));

			return _parameters;
		}
	}
}
