using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Maps.Roads.Common;
using Location = GoogleApi.Entities.Maps.Roads.Common.Location;

namespace GoogleApi.Entities.Maps.Roads.SnapToRoads.Request
{
    /// <summary>
    /// SnapToRoads Request.
    /// </summary>
    public class SnapToRoadsRequest : BaseRoadsRequest
    {
        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => "roads.googleapis.com/v1/snapToRoads";

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

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (this.Path == null || !this.Path.Any())
                    throw new ArgumentException("Path is required.");

                var parameters = base.QueryStringParameters;

                parameters.Add("path", string.Join("|", this.Path));
                parameters.Add("interpolate", this.Interpolate.ToString());

                return parameters;
            }
        }
    }
}