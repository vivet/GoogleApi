using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Roads.SnapToRoads.Request
{
    /// <summary>
    /// SnapToRoads Request.
    /// </summary>
    public class SnapToRoadsRequest : BaseMapsRequest
	{
		/// <summary>
        /// path — The path to be snapped (required). The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. 
        /// Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
		/// </summary>
        public virtual IEnumerable<Location> Path { get; set; } 
	
        /// <summary>
		/// Interpolate — Whether to interpolate a path to include all points forming the full road-geometry. 
		/// When true, additional interpolated points will also be returned, resulting in a path that smoothly follows the geometry of the road, even around corners and through tunnels. 
		/// Interpolated paths will most likely contain more points than the original path. Defaults to false.
		/// </summary>
        public virtual bool Interpolate { get; set; }

        protected internal override string BaseUrl
        {
            get { return "roads.googleapis.com/v1/snapToRoads/"; }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
		{
            if (this.Path == null || !this.Path.Any())
				throw new ArgumentException("Path is required");

			var _parameters = base.GetQueryStringParameters();

            _parameters.Add("path", string.Join("|", this.Path));
            _parameters.Add("interpolate", this.Interpolate.ToString());

			return _parameters;
		}
	}
}
