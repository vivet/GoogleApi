using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.Common.Enums;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Request
{
    /// <summary>
    /// Speed limits request.
    /// </summary>
    public class SpeedLimitsRequest : BaseRoadsRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => "roads.googleapis.com/v1/speedLimits";

        /// <summary>
        /// path — The path to be snapped (required or PlaceIds). 
        /// The path parameter accepts a list of latitude/longitude pairs. 
        /// Latitude and longitude values should be separated by commas. 
        /// Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
        /// </summary>
        public virtual IEnumerable<Location> Path { get; set; }

        /// <summary>
        /// placeId — The place ID of the road segment. 
        /// Place IDs are returned by the snapToRoads method. You can pass up to 100 placeIds with each request.
        /// </summary>
        public virtual IEnumerable<string> PlaceIds { get; set; }

        /// <summary>
        /// units (optional) — Whether to return speed limits in kilometers or miles per hour. This can be set to either KPH or MPH. Defaults to KPH.
        /// </summary>
        public virtual Units Unit { get; set; } = Units.Kph;

        /// <summary>
        /// See <see cref="BaseRoadsRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.Path == null || !this.Path.Any())
            {
                if (this.PlaceIds == null || !this.PlaceIds.Any())
                    throw new ArgumentException("Path or PlaceId's is required");

                if (this.PlaceIds.Count() > 100)
                    throw new ArgumentException("Max PlaceId's exceeded");

                foreach (var placeId in this.PlaceIds)
                {
                    parameters.Add("placeId", placeId);
                }
            }
            else
            {
                parameters.Add("path", string.Join("|", this.Path));
            }

            return parameters;
        }
    }
}