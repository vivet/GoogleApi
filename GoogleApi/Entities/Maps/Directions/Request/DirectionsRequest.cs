using System;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Directions.Request
{
	public class DirectionsRequest : SignableRequest
	{
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
        public virtual AvoidWay Avoid { get; set; }

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
        public virtual TravelMode TravelMode { get; set; }

        public DirectionsRequest()
        {
            this.Avoid = AvoidWay.Nothing;
            this.TravelMode = TravelMode.Driving;
        }

		protected override QueryStringParametersList GetQueryStringParameters()
		{
			if (string.IsNullOrWhiteSpace(this.Origin))
				throw new ArgumentException("Must specify an Origin");
            
            if (string.IsNullOrWhiteSpace(this.Destination))
				throw new ArgumentException("Must specify a Destination");
            
            if (!Enum.IsDefined(typeof(AvoidWay), this.Avoid))
				throw new ArgumentException("Invalid enumeration value for 'Avoid'");
            
            if (!Enum.IsDefined(typeof(TravelMode), this.TravelMode))
				throw new ArgumentException("Invalid enumeration value for 'TravelMode'");

            if (this.TravelMode == TravelMode.Transit && (this.DepartureTime == default(DateTime) && this.ArrivalTime == default(DateTime)))
				throw new ArgumentException("You must set either DepatureTime or ArrivalTime when TravelMode = Transit");

			var _parameters = base.GetQueryStringParameters();
            _parameters.Add("origin", this.Origin);
            _parameters.Add("destination", this.Destination);
            _parameters.Add("mode", this.TravelMode.ToString().ToLower());

            if (this.Alternatives)
				_parameters.Add("alternatives", "true");

            if (this.Avoid != AvoidWay.Nothing)
                _parameters.Add("avoid", this.Avoid.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(this.Language))
                _parameters.Add("language", this.Language);

            if (this.Waypoints != null && this.Waypoints.Any())
                _parameters.Add("waypoints", string.Join("|", this.OptimizeWaypoints ? new[] { "optimize:true" }.Concat(Waypoints) : this.Waypoints));

            if (this.ArrivalTime != default(DateTime))
                _parameters.Add("arrival_time", UnixTimeConverter.DateTimeToUnixTimestamp(this.ArrivalTime).ToString(CultureInfo.InvariantCulture));

		    if (this.DepartureTime != default(DateTime))
		        _parameters.Add("departure_time", UnixTimeConverter.DateTimeToUnixTimestamp(this.DepartureTime).ToString(CultureInfo.InvariantCulture));

			return _parameters;
		}
	}
}