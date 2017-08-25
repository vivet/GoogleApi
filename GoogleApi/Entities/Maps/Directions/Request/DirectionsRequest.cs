using System;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common.Enums;

namespace GoogleApi.Entities.Maps.Directions.Request
{
    /// <summary>
    /// Directions Request.
    /// </summary>
    public class DirectionsRequest : BaseMapsChannelRequest, IRequestQueryString
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "directions/json";

        /// <summary>
        /// origins — The starting point for calculating travel distance and time. 
        /// You can supply one or more locations separated by the pipe character (|), in the form of an address, latitude/longitude coordinates, or a placeID.
        /// If you pass an address, the service geocodes the string and converts it to a latitude/longitude coordinate to calculate distance.
        /// This coordinate may be different from that returned by the Google Maps Geocoding API, for example a building entrance rather than its center. 
        /// Example: "origins=Bobcaygeon+ON|24+Sussex+Drive+Ottawa+ON".
        /// If you pass latitude/longitude coordinates, they are used unchanged to calculate distance.
        /// Ensure that no space exists between the latitude and longitude values. If you supply a place ID, you must prefix it with place_id. 
        /// Example: "origins= 41.43206,-81.38992|-33.86748,151.20699".
        /// You can only specify a placeID if the request includes an API key or a Google Maps APIs Premium Plan client ID.
        /// You can retrieve place IDs from the Google Maps Geocoding API and the Google Places API (including Place Autocomplete). 
        /// For an example using place IDs from Place Autocomplete, see Place Autocomplete and Directions.For more about place IDs, see the place ID overview. "origins= place_id:ChIJ3S-JXmauEmsRUcIaWtf4MzE".
        /// </summary>
        public virtual Location Origin { get; set; }

        /// <summary>
        /// The address, textual latitude/longitude value, or place ID to which you wish to calculate directions. 
        /// The options for the destination parameter are the same as for the <see cref="Origin"/> parameter, described above.
        /// </summary>
        public virtual Location Destination { get; set; }

        /// <summary>
        /// Directions results contain text within distance fields to indicate the distance of the calculated route. The unit system to use can be specified:
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
        /// The time of arrival.
        /// Required when TravelMode = Transit
        /// </summary>
        public virtual DateTime? ArrivalTime { get; set; }

        /// <summary>
        /// The time of departure.
        /// Required when TravelMode = Transit
        /// </summary>
        public virtual DateTime? DepartureTime { get; set; }
  
        /// <summary>
        /// Waypoints (optional) specifies an array of waypoints. Waypoints alter a route by routing it through the specified location(s). 
        /// A waypoint is specified as either a latitude/longitude coordinate or as an address which will be geocoded. 
        /// (For more information on waypoints, see Using Waypoints in Routes below.)
        /// If you'd like to influence the route using waypoints without adding a stopover, prefix the waypoint with 'via:' (deprecated On Aug 20, 2017)
        /// Waypoints prefixed with via: will not add an entry to the legs array, but will instead route the journey through the provided waypoint.
        /// The via: prefix is most effective when creating routes in response to the user dragging the waypoints on the map. 
        /// Doing so allows the user to see how the final route may look in real-time and helps ensure that waypoints are placed in locations that 
        /// are accessible to the Google Maps Directions API.
        /// Caution: Using the via: prefix to avoid stopovers results in directions that are very strict in their interpretation of the waypoint. 
        /// This may result in severe detours on the route or ZERO_RESULTS in the response status code if the Google Maps Directions API is unable to create directions 
        /// through that point.
        /// </summary>
        public virtual Location[] Waypoints { get; set; }

        /// <summary>
        /// Optimize the provided route by rearranging the waypoints in a more efficient order. 
        /// (This optimization is an application of the Travelling Salesman Problem.)
        /// Default: false.
        /// http://en.wikipedia.org/wiki/Travelling_salesman_problem
        /// </summary>
        public virtual bool OptimizeWaypoints { get; set; } = false;

        /// <summary>
        /// Alternatives (optional), if set to true, specifies that the Directions service may provide more than one route alternative in the response. 
        /// Note that providing route alternatives may increase the response time from the server.
        /// Default: false.
        /// </summary>
        public virtual bool Alternatives { get; set; } = false;

        /// <summary>
        /// Specifies the region code, specified as a ccTLD ("top-level domain") two-character value. (For more information see Region Biasing below.)
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// Language (optional) — The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the Directions service will attempt to use the native language of the browser wherever possible. 
        /// You may also explicitly bias the results by using localized domains of http://map.google.com. 
        /// See Region Biasing for more information.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// <see cref="BaseMapsChannelRequest.GetQueryStringParameters()"/>
        /// </summary>
        /// <returns>The <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            if (this.Origin == null)
                throw new ArgumentException("Origin is required");

            if (this.Destination == null)
                throw new ArgumentException("Destination is required");

            if (this.TravelMode == TravelMode.Transit && this.DepartureTime == null && this.ArrivalTime == null)
                throw new ArgumentException("DepatureTime or ArrivalTime is required, when TravelMode is Transit");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("origin", this.Origin.ToString());
            parameters.Add("destination", this.Destination.ToString());
            parameters.Add("units", this.Units.ToString().ToLower());
            parameters.Add("mode", this.TransitMode.ToString().ToLower());
            parameters.Add("language", this.Language.ToCode());

            if (this.Region != null)
                parameters.Add("region", this.Region);

            if (this.Alternatives)
                parameters.Add("alternatives", "true");

            if (this.Avoid != AvoidWay.Nothing)
                parameters.Add("avoid", this.Avoid.ToEnumString('|'));

            if (this.Waypoints != null && this.Waypoints.Any())
            {
                var waypoints = this.Waypoints.Select(x => x.ToString());
                parameters.Add("waypoints", string.Join("|", this.OptimizeWaypoints ? new[] { "optimize:true" }.Concat(waypoints) : waypoints));
            }

            if (this.TravelMode != TravelMode.Transit)
                return parameters;

            parameters.Add("transit_mode", this.TransitMode.ToEnumString('|'));

            if (this.TransitRoutingPreference != TransitRoutingPreference.Nothing)
                parameters.Add("transit_routing_preference", this.TransitRoutingPreference.ToEnumString('|'));

            if (this.ArrivalTime != null)
                parameters.Add("arrival_time", this.ArrivalTime.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

            if (this.DepartureTime != null)
                parameters.Add("departure_time", this.DepartureTime.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

            return parameters;
        }
    }
}