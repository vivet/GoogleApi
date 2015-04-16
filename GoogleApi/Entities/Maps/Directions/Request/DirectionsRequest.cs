using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Extensions;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Directions.Request
{
	public class DirectionsRequest : SignableRequest
	{
	    private AvoidWay _avoid = AvoidWay.Nothing;
        private TravelMode _travelMode = TravelMode.Driving;

	    protected internal override string BaseUrl
		{
			get
			{
				return base.BaseUrl + "directions/";
			}
		}

		/// <summary>
		/// origin (required) — The address or textual latitude/longitude value from which you wish to calculate directions. *
		/// </summary>
        public virtual string Origin { get; set; }

		/// <summary>
		/// destination (required) — The address or textual latitude/longitude value from which you wish to calculate directions.*
		/// </summary>
        public virtual string Destination { get; set; }

		/// <summary>
		/// The time of departure.
		/// Required when TravelMode = Transit
		/// </summary>
        public virtual DateTime DepartureTime { get; set; }

		/// <summary>
		/// The time of arrival.
		/// Required when TravelMode = Transit
		/// </summary>
        public virtual DateTime ArrivalTime { get; set; }

		/// <summary>
		/// waypoints (optional) specifies an array of waypoints. Waypoints alter a route by routing it through the specified location(s). A waypoint is specified as either a latitude/longitude coordinate or as an address which will be geocoded. (For more information on waypoints, see Using Waypoints in Routes below.)
		/// </summary>
        public virtual string[] Waypoints { get; set; }

		/// <summary>
		/// optimize the provided route by rearranging the waypoints in a more efficient order. (This optimization is an application of the Travelling Salesman Problem.)
		/// http://en.wikipedia.org/wiki/Travelling_salesman_problem
		/// </summary>
        public virtual bool OptimizeWaypoints { get; set; }

		/// <summary>
		/// alternatives (optional), if set to true, specifies that the Directions service may provide more than one route alternative in the response. Note that providing route alternatives may increase the response time from the server.
		/// </summary>
        public virtual bool Alternatives { get; set; }

	    /// <summary>
	    /// avoid (optional) indicates that the calculated route(s) should avoid the indicated features. Currently, this parameter supports the following two arguments:
	    /// tolls indicates that the calculated route should avoid toll roads/bridges.
	    /// highways indicates that the calculated route should avoid highways.
	    /// (For more information see Route Restrictions below.)
	    /// </summary>
	    public virtual AvoidWay Avoid
	    {
	        get { return _avoid; }
	        set { _avoid = value; }
	    }

	    /// <summary>
	    /// language (optional) — The language in which to return results. See the supported list of domain languages. 
	    /// Note that we often update supported languages so this list may not be exhaustive. 
	    /// If language is not supplied, the Directions service will attempt to use the native language of the browser wherever possible. 
	    /// You may also explicitly bias the results by using localized domains of http://map.google.com. 
	    /// See Region Biasing for more information.
	    /// </summary>
	    public virtual string Language { get; set; }

	    /// <summary>
	    /// (optional, defaults to driving) — specifies what mode of transport to use when calculating directions. Valid values are specified in Travel Modes.
	    /// </summary>
	    public virtual TravelMode TravelMode
	    {
	        get { return _travelMode; }
	        set { _travelMode = value; }
	    }

        protected override IDictionary<string, string> GetQueryStringParameters()
		{
			if (string.IsNullOrWhiteSpace(Origin))
				throw new ArgumentException("Must specify an Origin");
            
            if (string.IsNullOrWhiteSpace(Destination))
				throw new ArgumentException("Must specify a Destination");
            
            if (!Enum.IsDefined(typeof(AvoidWay), Avoid))
				throw new ArgumentException("Invalid enumeration value for 'Avoid'");
            
            if (!Enum.IsDefined(typeof(TravelMode), TravelMode))
				throw new ArgumentException("Invalid enumeration value for 'TravelMode'");

            if (TravelMode == TravelMode.Transit && (DepartureTime == default(DateTime) && ArrivalTime == default(DateTime)))
				throw new ArgumentException("You must set either DepatureTime or ArrivalTime when TravelMode = Transit");

			var parameters = base.GetQueryStringParameters();
            parameters.Add("origin", Origin);
            parameters.Add("destination", Destination);
            parameters.Add("mode", TravelMode.ToString().ToLower());

            if (Alternatives)
				parameters.Add("alternatives", "true");

            if (Avoid != AvoidWay.Nothing)
                parameters.Add("avoid", Avoid.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(Language))
                parameters.Add("language", Language);

            if (Waypoints != null && Waypoints.Any())
                parameters.Add("waypoints", string.Join("|", OptimizeWaypoints ? new[] { "optimize:true" }.Concat(Waypoints) : Waypoints));

            if (ArrivalTime != default(DateTime))
                parameters.Add("arrival_time", ArrivalTime.ToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

		    if (DepartureTime != default(DateTime))
                parameters.Add("departure_time", DepartureTime.ToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

			return parameters;
		}
	}
}