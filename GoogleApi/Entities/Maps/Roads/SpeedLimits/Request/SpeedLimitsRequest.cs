using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Request
{
    /// <summary>
    /// SpeedLimits Request.
    /// </summary>
    public class SpeedLimitsRequest : BaseMapsRequest, IQueryStringRequest
    {
        /// <summary>
        /// path — The path to be snapped (required or PlaceIds). The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
        /// </summary>
        public virtual IEnumerable<Location> Path { get; set; }

        /// <summary>
        /// placeId — The place ID of the road segment. Place IDs are returned by the snapToRoads method. You can pass up to 100 placeIds with each request.
        /// </summary>
        public virtual IEnumerable<string> PlaceIds { get; set; }

        /// <summary>
        /// units (optional) — Whether to return speed limits in kilometers or miles per hour. This can be set to either KPH or MPH. Defaults to KPH.
        /// </summary>
        public virtual Units Unit { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => "roads.googleapis.com/v1/speedLimits";

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if ((this.Path == null || !this.Path.Any()) && (this.PlaceIds == null || !this.PlaceIds.Any()))
                throw new ArgumentException("Path OR PlaceIds is required");

            var parameters = base.GetQueryStringParameters();

            if (this.Path != null && this.Path.Any())
                parameters.Add("path", string.Join("|", this.Path));

            if (this.PlaceIds != null && this.PlaceIds.Any())
            {
                if (this.PlaceIds.Count() > 100)
                    throw new ArgumentException("Max 100 PlaceIds is allowed");

                foreach (var placeId in this.PlaceIds)
                {
                    parameters.Add("placeId", placeId);
                }
            }

            return parameters;
        }
    }
}