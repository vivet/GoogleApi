using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common.Enums;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Request
{
    /// <summary>
    /// Distance Matrix Request.
    /// </summary>
    public class DistanceMatrixRequest : BaseMapsChannelRequest, IRequestQueryString
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "distancematrix/json";

        /// <summary>
        /// origins — The starting point for calculating travel distance and time. 
        /// You can supply one or more locations separated by the pipe character (|), in the form of an address, latitude/longitude coordinates, 
        /// or a placeID. If you pass an address, the service geocodes the string and converts it to a latitude/longitude coordinate to calculate distance.
        /// This coordinate may be different from that returned by the Google Maps Geocoding API, for example a building entrance rather than its center. 
        /// Example: "origins=Bobcaygeon+ON|24+Sussex+Drive+Ottawa+ON".
        /// If you pass latitude/longitude coordinates, they are used unchanged to calculate distance.
        /// Ensure that no space exists between the latitude and longitude values. If you supply a place ID, you must prefix it with place_id. 
        /// Example: "origins= 41.43206,-81.38992|-33.86748,151.20699".
        /// You can only specify a placeID if the request includes an API key or a Google Maps APIs Premium Plan client ID.
        /// You can retrieve place IDs from the Google Maps Geocoding API and the Google Places API (including Place Autocomplete). 
        /// For an example using place IDs from Place Autocomplete, see Place Autocomplete and Directions.For more about place IDs, see the place ID overview. 
        /// "origins= place_id:ChIJ3S-JXmauEmsRUcIaWtf4MzE".
        /// Alternatively, you can supply an encoded set of coordinates using the Encoded Polyline Algorithm.
        /// This is particularly useful if you have a large number of origin points, because the URL is significantly shorter when using an encoded polyline. 
        /// Example: Encoded polylines must be prefixed with enc: and followed by a colon (:). Example: "origins=enc:gfo}EtohhU:".
        /// You can also include multiple encoded polylines, separated by the pipe character(|). 
        /// Example: "origins=enc:wc ~oAwquwMdlTxiKtqLyiK:|enc:c ~vnAamswMvlTor@tjGi}L:|enc:udymA{~bxM:".
        /// </summary>
        public virtual string OriginsRaw { get; set; }

        /// <summary>
        /// destinations — One or more locations to use as the finishing point for calculating travel distance and time. 
        /// The options for the destinations parameter are the same as for the <see cref="OriginsRaw"/> parameter, described above.
        /// </summary>
        public virtual string DestinationsRaw { get; set; }

        /// <summary>
        /// One or more addresses and/or textual latitude/longitude values, separated with the pipe (|) character, from which to calculate distance and time. 
        /// If you pass an address as a string, the service will geocode the string and convert it to a latitude/longitude coordinate to calculate directions. 
        /// If you pass coordinates, ensure that no space exists between the latitude and longitude values.
        /// </summary>
        public virtual IEnumerable<Location> Origins { get; set; }

        /// <summary>
        /// One or more addresses and/or textual latitude/longitude values, separated with the pipe (|) character, to which to calculate distance and time. 
        /// If you pass an address as a string, the service will geocode the string and convert it to a latitude/longitude coordinate to calculate directions. 
        /// If you pass coordinates, ensure that no space exists between the latitude and longitude values
        /// </summary>
        public virtual IEnumerable<Location> Destinations { get; set; }

        /// <summary>
        /// Distance Matrix results contain text within distance fields to indicate the distance of the calculated route. 
        /// The unit system to use can be specified:  Units=metric (default) returns distances in kilometers and meters.
        /// Units=imperial returns distances in miles and feet.
        /// * Note: this unit system setting only affects the text displayed within distance fields. 
        /// The distance fields also contain values which are always expressed in meters
        /// </summary>
        public virtual Units Units { get; set; } = Units.Metric;

        /// <summary>
        /// avoid (optional) indicates that the calculated route(s) should avoid the indicated features. 
        /// Currently, this parameter supports the following two arguments: 
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
        /// Traffic mdel (defaults to best_guess).
        /// Specifies the assumptions to use when calculating time in traffic. This setting affects the value returned 
        /// in the duration_in_traffic field in the response, which contains the predicted time in traffic based on historical averages.
        /// The traffic_model parameter may only be specified for requests where the travel mode is driving, and where the request includes a departure_time, 
        /// and only if the request includes an API key or a Google Maps APIs Premium Plan client ID.The available values for this parameter are:
        /// </summary>
        public virtual TrafficModel TrafficModel { get; set; } = TrafficModel.Best_Guess;

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
        /// The desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. Alternatively, 
        /// you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). 
        /// The departure time may be specified in two cases:
        /// - For requests where the travel mode is transit: You can optionally specify one of departure_time or arrival_time. If neither time is specified, 
        ///   the departure_time defaults to now (that is, the departure time defaults to the current time).
        /// - For requests where the travel mode is driving: Google Maps API for Work customers can specify the departure_time to receive trip duration considering 
        ///   current traffic conditions. The departure_time must be set to within a few minutes of the current time.
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
        /// <see cref="BaseMapsChannelRequest.GetQueryStringParameters()"/>
        /// </summary>
        /// <returns>The <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            if (string.IsNullOrEmpty(this.OriginsRaw) && (this.Origins == null || !this.Origins.Any()))
                throw new ArgumentException("Origins is required");

            if (string.IsNullOrEmpty(this.DestinationsRaw) && (this.Destinations == null || !this.Destinations.Any()))
                throw new ArgumentException("Destinations is required");

            if (this.TravelMode == TravelMode.Transit && this.DepartureTime == null && this.ArrivalTime == null)
                throw new ArgumentException("DepatureTime or ArrivalTime is required, when TravelMode is Transit");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("language", this.Language.ToCode());
            parameters.Add("units", this.Units.ToString().ToLower());
            parameters.Add("mode", this.TravelMode.ToString().ToLower());
            parameters.Add("origins", string.IsNullOrEmpty(this.OriginsRaw) ? string.Join("|", this.Origins) : this.OriginsRaw);
            parameters.Add("destinations", string.IsNullOrEmpty(this.DestinationsRaw) ? string.Join("|", this.Destinations) : this.DestinationsRaw);

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

            if (this.TravelMode == TravelMode.Driving)
            {
                if (this.DepartureTime != null)
                {
                    parameters.Add("departure_time", this.DepartureTime.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

                    if (this.Key != null || this.ClientId != null)
                        parameters.Add("traffic_model", this.TrafficModel.ToString().ToLower());
                }
            }

            return parameters;
        }
    }
}