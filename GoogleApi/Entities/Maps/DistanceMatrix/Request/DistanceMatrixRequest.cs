using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Request
{
    /// <summary>
    /// DistanceMatrix Request.
    /// </summary>
    public class DistanceMatrixRequest : BaseMapsRequest, IQueryStringRequest
    {
        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "distancematrix/json";

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
        public virtual Units Units { get; set; } = Units.Metric;

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
        public virtual AvoidWay Avoid { get; set; } = AvoidWay.Nothing;

        /// <summary>
        /// (optional, defaults to driving) — specifies what mode of transport to use when calculating directions. Valid values are specified in Travel Modes.
        /// </summary>
        public virtual TravelMode TravelMode { get; set; } = TravelMode.Driving;

        /// <summary>
        /// Specifies one or more preferred modes of transit. 
        /// This parameter may only be specified for requests where the mode is transit. 
        /// The parameter supports the following arguments <see cref="Common.Enums.TransitMode"/>
        /// </summary>
        public virtual TransitMode TransitMode { get; set; } = TransitMode.Bus | TransitMode.Train | TransitMode.Subway | TransitMode.Tram;

        /// <summary>
        /// Specifies preferences for transit requests. 
        /// Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. 
        /// This parameter may only be specified for requests where the mode is transit. 
        /// The parameter supports the following arguments: <see cref="Common.Enums.TransitRoutingPreference"/>
        /// </summary>
        public virtual TransitRoutingPreference TransitRoutingPreference { get; set; } = TransitRoutingPreference.Nothing;

        /// <summary>
        /// The desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. Alternatively, you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). 
        /// The departure time may be specified in two cases:
        /// - For requests where the travel mode is transit: You can optionally specify one of departure_time or arrival_time. If neither time is specified, the departure_time defaults to now (that is, the departure time defaults to the current time).
        /// - For requests where the travel mode is driving: Google Maps API for Work customers can specify the departure_time to receive trip duration considering current traffic conditions. The departure_time must be set to within a few minutes of the current time.
        /// Note: Requests that include the departure_time parameter are limited to 100 elements
        /// Note: You can specify either DepartureTime or ArrivalTime, but not both
        /// </summary>
        public virtual DateTime? DepartureTime { get; set; }

        /// <summary>
        /// Specifies the desired time of arrival for transit requests, in seconds since midnight, January 1, 1970 UTC. 
        /// Note: You can specify either DepartureTime or ArrivalTime, but not both
        /// </summary>
        public virtual DateTime? ArrivalTime { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the Directions service will attempt to use the native language of the browser wherever possible. 
        /// You may also explicitly bias the results by using localized domains of http://map.google.com. 
        /// See Region Biasing for more information.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (this.Origins == null || !this.Origins.Any())
                    throw new ArgumentException("Origins is required.");

                if (this.Destinations == null || !this.Destinations.Any())
                    throw new ArgumentException("Destinations is required.");

                if (this.TravelMode == TravelMode.Transit && this.DepartureTime == null && this.ArrivalTime == null)
                    throw new ArgumentException("DepatureTime or ArrivalTime is required, when TravelMode is Transit.");

                var parameters = base.QueryStringParameters;

                parameters.Add("origins", string.Join("|", this.Origins));
                parameters.Add("destinations", string.Join("|", this.Destinations));
                parameters.Add("mode", this.TravelMode.ToString().ToLower());
                parameters.Add("units", this.Units.ToString().ToLower());
                parameters.Add("language", this.Language.ToCode());

                if (this.Avoid != AvoidWay.Nothing)
                    parameters.Add("avoid", this.Avoid.ToEnumString('|'));

                if (this.TravelMode == TravelMode.Transit)
                {
                    parameters.Add("transit_mode", this.TransitMode.ToEnumString('|'));

                    if (this.TransitRoutingPreference != TransitRoutingPreference.Nothing)
                        parameters.Add("transit_routing_preference", this.TransitRoutingPreference.ToEnumString('|'));

                    if (this.ArrivalTime != null)
                        parameters.Add("arrival_time", this.ArrivalTime.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

                    if (this.DepartureTime != null)
                        parameters.Add("departure_time", this.DepartureTime.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));
                }

                return parameters;
            }
        }
    }
}