using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Maps.TimeZone.Request
{
    /// <summary>
    /// TimeZone Request.
    /// </summary>
    public class TimeZoneRequest : BaseMapsChannelRequest, IQueryStringRequest
    {
        private const string BASE_URL = "maps.googleapis.com/maps/api/timezone/json";

        /// <summary>
        /// A comma-separated lat,lng tuple (eg. location=-33.86,151.20), representing the location to look up
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Timestamp specifies the desired time as seconds since midnight, January 1, 1970 UTC. 
        /// The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied. Times before 1970 can be expressed as negative values.
        /// </summary>
        public virtual DateTime TimeStamp { get; set; }

        /// <summary>
        /// The language in which to return results. See the list of supported domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. Defaults to en.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => TimeZoneRequest.BASE_URL;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (this.Location == null)
                    throw new ArgumentException("Location is required.");

                if (this.TimeStamp == null)
                    throw new ArgumentException("TimeStamp is required.");

                var parameters = base.QueryStringParameters;

                parameters.Add("location", this.Location.LocationString);
                parameters.Add("timestamp", this.TimeStamp.DateTimeToUnixTimestamp().ToString());
                parameters.Add("language", this.Language.ToCode());

                return parameters;
            }
        }
    }
}