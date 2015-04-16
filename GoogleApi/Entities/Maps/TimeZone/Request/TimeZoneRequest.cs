using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.TimeZone.Request
{
    public class TimeZoneRequest : SignableRequest
    {
        protected internal override string BaseUrl
        {
            get { return "maps.googleapis.com/maps/api/timezone/"; }
        }

        /// <summary>
        /// A comma-separated lat,lng tuple (eg. location=-33.86,151.20), representing the location to look up
        /// </summary>
        public virtual Location Location { get; set; } 

        /// <summary>
        /// Timestamp specifies the desired time as seconds since midnight, January 1, 1970 UTC. The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied. Times before 1970 can be expressed as negative values.
        /// </summary>
        public virtual DateTime TimeStamp { get; set; }
        
        /// <summary>
        /// The language in which to return results. See the list of supported domain languages. Note that we often update supported languages so this list may not be exhaustive. Defaults to en.
        /// </summary>
        public virtual string Language { get; set; } 

        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, TimeZoneRequest must use SSL"); }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (Location == null)
                throw new ArgumentException("Location is required");

            if (TimeStamp == null)
                throw new ArgumentException("TimeStamp is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("location", Location.LocationString);
            parameters.Add("timestamp", UnixTimeConverter.DateTimeToUnixTimestamp(TimeStamp).ToString());

            if (!string.IsNullOrWhiteSpace(Language)) 
                parameters.Add("language", Language);

            return parameters;
        }
    }
}