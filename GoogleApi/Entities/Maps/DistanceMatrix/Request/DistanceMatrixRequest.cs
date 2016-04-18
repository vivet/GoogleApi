using System;
using System.Collections.Generic;
using System.Globalization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Request
{
    /// <summary>
    /// DistanceMatrix Request.
    /// </summary>
    public class DistanceMatrixRequest : BaseMapsRequest
	{
		/// <summary>
        /// One or more addresses and/or textual latitude/longitude values, separated with the pipe (|) character, from which to calculate distance and time. If you pass an address as a string, 
        /// the service will geocode the string and convert it to a latitude/longitude coordinate to calculate directions. If you pass coordinates, ensure that no space exists between the latitude and longitude values.
		/// </summary>
        public virtual IEnumerable<ILocationString> Origins { get; set; }

        /// <summary>
        /// One or more addresses and/or textual latitude/longitude values, separated with the pipe (|) character, to which to calculate distance and time. 
        /// If you pass an address as a string, the service will geocode the string and convert it to a latitude/longitude coordinate to calculate directions. If you pass coordinates, ensure that no space exists between the latitude and longitude values
		/// </summary>
        public virtual IEnumerable<ILocationString> Destinations { get; set; }
        
        /// <summary>
        /// Distance Matrix results contain text within distance fields to indicate the distance of the calculated route. The unit system to use can be specified:
        /// Units=metric (default) returns distances in kilometers and meters.
        /// Units=imperial returns distances in miles and feet.
        /// * Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters
        /// </summary>
        public virtual Units Units { get; set; }
        
        /// <summary>
        /// avoid (optional) indicates that the calculated route(s) should avoid the indicated features. Currently, this parameter supports the following two arguments:
        /// tolls indicates that the calculated route should avoid toll roads/bridges.
        /// highways indicates that the calculated route should avoid highways.
        /// (For more information see Route Restrictions below.)
        /// 
        /// Restrictions:
        /// Directions may be calculated that adhere to certain restrictions. 
        /// Restrictions are indicated by use of the avoid parameter, and an argument to that parameter indicating the restriction to avoid. 
        /// The following estrictions are supported <see cref="GoogleApi.Entities.Maps.Common.Enums.AvoidWay"/>
        /// </summary>
        public virtual AvoidWay Avoid { get; set; }
        
        /// <summary>
        /// (optional, defaults to driving) — specifies what mode of transport to use when calculating directions. Valid values are specified in Travel Modes.
        /// </summary>
        public virtual TravelMode TravelMode { get; set; }
        
        /// <summary>
        /// Specifies one or more preferred modes of transit. 
        /// This parameter may only be specified for requests where the mode is transit. 
        /// The parameter supports the following arguments <see cref="Common.Enums.TransitMode"/>
        /// </summary>
        public virtual TransitMode TransitMode { get; set; }
        
        /// <summary>
        /// Specifies preferences for transit requests. 
        /// Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. 
        /// This parameter may only be specified for requests where the mode is transit. 
        /// The parameter supports the following arguments: <see cref="Common.Enums.TransitRoutingPreference"/>
        /// </summary>
        public virtual TransitRoutingPreference TransitRoutingPreference { get; set; }
        
        /// <summary>
        /// The desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. Alternatively, you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). 
        /// The departure time may be specified in two cases:
        /// - For requests where the travel mode is transit: You can optionally specify one of departure_time or arrival_time. If neither time is specified, the departure_time defaults to now (that is, the departure time defaults to the current time).
        /// - For requests where the travel mode is driving: Google Maps API for Work customers can specify the departure_time to receive trip duration considering current traffic conditions. The departure_time must be set to within a few minutes of the current time.
        /// Note: Requests that include the departure_time parameter are limited to 100 elements
        /// Note: You can specify either DepartureTime or ArrivalTime, but not both
        /// </summary>
        public virtual DateTime DepartureTime { get; set; }
        
        /// <summary>
        /// Specifies the desired time of arrival for transit requests, in seconds since midnight, January 1, 1970 UTC. 
        /// Note: You can specify either DepartureTime or ArrivalTime, but not both
        /// </summary>
        public virtual DateTime ArrivalTime { get; set; }
        
        /// <summary>
        /// language (optional) — The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the Directions service will attempt to use the native language of the browser wherever possible. 
        /// You may also explicitly bias the results by using localized domains of http://map.google.com. 
        /// See Region Biasing for more information.
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// Defatult Constructor
        /// </summary>
        public DistanceMatrixRequest()
        {
            this.Units = Units.METRIC;
            this.Avoid = AvoidWay.NOTHING;
            this.TravelMode = TravelMode.DRIVING;
            this.TransitMode = TransitMode.BUS | TransitMode.TRAIN | TransitMode.SUBWAY | TransitMode.TRAM;
            this.TransitRoutingPreference = TransitRoutingPreference.NOTHING;
        }

        protected  internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "distancematrix/";
            }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
		{
			if (this.Origins == null)
				throw new ArgumentException("Must specify an Origins");

            if (this.Destinations == null)
				throw new ArgumentException("Must specify a Destinations");
            
            if (!Enum.IsDefined(typeof(AvoidWay), this.Avoid))
				throw new ArgumentException("Invalid enumeration value for 'Avoid'");

            if (!Enum.IsDefined(typeof(TravelMode), this.TravelMode))
				throw new ArgumentException("Invalid enumeration value for 'TravelMode'");

            if (this.TravelMode == TravelMode.TRANSIT && this.DepartureTime == default(DateTime) && this.ArrivalTime == default(DateTime))
                throw new ArgumentException("You must set either DepatureTime or ArrivalTime when TravelMode = Transit");

			var _parameters = base.GetQueryStringParameters();

            _parameters.Add("origins", string.Join("|", this.Origins));
            _parameters.Add("destinations", string.Join("|", this.Destinations));
            _parameters.Add("mode", this.TravelMode.ToString().ToLower());
            _parameters.Add("units", this.Units.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(this.Language))
                _parameters.Add("language", this.Language);

            if (this.Avoid != AvoidWay.NOTHING)
                _parameters.Add("avoid", this.Avoid.ToString('|'));

            if (this.TravelMode == TravelMode.TRANSIT)
            {
                _parameters.Add("transit_mode", this.TransitMode.ToString('|'));

                if (this.TransitRoutingPreference != TransitRoutingPreference.NOTHING)
                    _parameters.Add("transit_routing_preference", this.TransitRoutingPreference.ToString('|'));

                if (this.ArrivalTime != default(DateTime))
                    _parameters.Add("arrival_time", UnixTimeConverter.DateTimeToUnixTimestamp(this.ArrivalTime).ToString(CultureInfo.InvariantCulture));

                if (this.DepartureTime != default(DateTime))
                    _parameters.Add("departure_time", UnixTimeConverter.DateTimeToUnixTimestamp(this.DepartureTime).ToString(CultureInfo.InvariantCulture));
            }

			return _parameters;
		}
	}
}