﻿using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Elevation.Response;
using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geolocation.Response;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Response;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Response;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Response;
using GoogleApi.Entities.Maps.StreetView.Request;
using GoogleApi.Entities.Maps.StreetView.Response;
using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Entities.Maps.TimeZone.Response;
using System.Net.Http;

namespace GoogleApi
{
    /// <summary>
    /// The Google Maps Web Services are a collection of HTTP interfaces to Google services providing geographic data for your maps applications.
    /// - Google Maps Directions API
    /// - Google Maps Distance Matrix API
    /// - Google Maps Elevation API
    /// - Google Maps Geocoding API
    /// - Google Maps Geolocation API
    /// - Google Maps Roads API
    /// - Google Maps Time Zone API
    /// Documentation: https://developers.google.com/maps/documentation
    /// </summary>
    public partial class GoogleMaps
    {

        /// <summary>
        /// Geocoding is the process of converting addresses (like "1600 Amphitheatre Parkway, Mountain View, CA") into
        /// geographic coordinates (like latitude 37.423021 and longitude -122.083739), which you can use to place markers on a map, or position the map.
        /// This is the process of converting a place id into a address.
        /// </summary>
        public static PlaceGeoCodeApi PlaceGeocode => new();


        /// <summary>
        /// Geocoding is the process of converting addresses (like "1600 Amphitheatre Parkway, Mountain View, CA") into
        /// geographic coordinates (like latitude 37.423021 and longitude -122.083739), which you can use to place markers on a map, or position the map.
        /// https://developers.google.com/maps/documentation/geocoding/intro#geocoding
        /// </summary>
        public static AddressGeocodeApi AddressGeocode => new();


        /// <summary>
        /// The term geocoding generally refers to translating a human-readable address into a location on a map.
        /// The process of doing the opposite, translating a location on the map into a human-readable address, is known as reverse geocoding.
        /// https://developers.google.com/maps/documentation/geocoding/intro#ReverseGeocoding
        /// </summary>
        public static LocationGeocodeApi LocationGeocode => new();
        /// <summary>
        /// The pluscode api is the process of converting a location (lat/lng or address) to a plus code (including the bounding box and the center).
        /// This API is experimental.
        /// As of December 2016, we are soliciting feedback on the functionality, in order to inform proposals to geocoding API providers such as Google.
        /// You can discuss the API in the public mailing list or create an issue in the issue tracker.
        /// https://github.com/google/open-location-code/wiki/Plus-codes-API
        /// </summary>
        public static PlusCodeGeocodeApi PlusCodeGeocode => new();
        /// <summary>
        /// The Google Maps Geolocation API returns a location and accuracy radius based on information about cell towers and WiFi nodes that the mobile client can detect.
        /// This document describes the protocol used to send this data to the server and to return a response to the client.
        /// Communication is done over HTTPS using POST. Both request and response are formatted as JSON, and the content type of both is application/json.
        /// Before you start developing with the Geolocation API, review the authentication requirements (you need an API key) and the API usage limits.
        /// https://developers.google.com/maps/documentation/geolocation/intro
        /// </summary>
        public static GeolocationApi Geolocation => new();

        /// <summary>
        /// The Google Maps Elevation API provides you a simple interface to query locations on the earth for elevation data. Additionally,
        /// you may request sampled elevation data along paths, allowing you to calculate elevation changes along routes.
        /// https://developers.google.com/maps/documentation/elevation/intro
        /// </summary>
        public static ElevationApi Elevation => new();

        /// <summary>
        /// Google Maps Directions API is a service that calculates directions between locations using an HTTP request.
        /// You can search for directions for several modes of transportation, include transit, driving, walking or cycling. Directions may specify origins,
        /// destinations and waypoints either as text strings (e.g. "Chicago, IL" or "Darwin, NT, Australia") or as latitude/longitude coordinates.
        /// The Directions API can return multi-part directions using a series of waypoints.
        /// This service is generally designed for calculating directions for static (known in advance) addresses for placement of application content on a map;
        /// this service is not designed to respond in real time to user input, for example.
        /// For dynamic directions calculations (for example, within a user interface element), consult the documentation for the Google Maps JavaScript API Directions Service.
        /// Calculating directions is a time and resource intensive task. Whenever possible, calculate known addresses ahead of time (using the service described here)
        /// and store your results in a temporary cache of your own design.
        /// https://developers.google.com/maps/documentation/directions/intro
        /// </summary>
        public static DirectionsApi Directions => new();

        /// <summary>
        /// The Google Maps Distance Matrix API is a service that provides travel distance and time for a matrix of origins and destinations.
        /// The information returned is based on the recommended route between start and end points, as calculated by the Google Maps API,
        /// and consists of rows containing duration and distance values for each pair.
        /// https://developers.google.com/maps/documentation/distance-matrix/intro
        /// </summary>
        public static DistanceMatrixApi DistanceMatrix => new();

        /// <summary>
        /// The Google Maps Time Zone API provides a simple interface to request the time zone for a location on the earth, as well as that location's time offset from UTC.
        /// The Google Maps Time Zone API provides time offset data for locations on the surface of the earth.
        /// Requesting the time zone information for a specific Latitude/Longitude pair will return the name of that time zone, the time offset from UTC, and the Daylight Savings offset.
        /// https://developers.google.com/maps/documentation/timezone/intro
        /// </summary>
        public static TimeZoneApi TimeZone => new();

        /// <summary>
        /// The snapToRoads method takes up to 100 GPS points collected along a route, and returns a similar set of data,
        /// with the points snapped to the most likely roads the vehicle was traveling along. Optionally, you can request that the points be interpolated,
        /// resulting in a path that smoothly follows the geometry of the road.
        /// https://developers.google.com/maps/documentation/roads/snap
        /// </summary>
        public static SnapToRoadApi SnapToRoad => new();

        /// <summary>
        /// The Google Maps Roads API takes takes up to 100 independent coordinates, and returns the closest road segment for each point.
        /// The points passed do not need to be part of a continuous path.
        /// NOTE: If you are working with sequential GPS points, use Snap to Roads.
        /// https://developers.google.com/maps/documentation/roads/nearest
        /// </summary>
        public static NearestRoadsApi NearestRoads => new();

        /// <summary>
        /// The speedLimits method returns the posted speed limit for a given road segment.
        /// In the case of road segments with variable speed limits, the default speed limit for the segment is returned.
        /// The accuracy of speed limit data returned by the Google Maps Roads API cannot be guaranteed. The speed limit data provided is not real-time,
        /// and may be estimated, inaccurate, incomplete, and/or outdated. Inaccuracies in our data may be reported through the Google Map Maker service.
        /// https://developers.google.com/maps/documentation/roads/speed-limits
        /// </summary>
        public static SpeedLimitsApi SpeedLimits => new();

        /// <summary>
        /// The Google Street View Image API lets you embed a static (non-interactive) Street View panorama or thumbnail into your web page, without the use of JavaScript.
        /// The viewport is defined with URL parameters sent through a standard HTTP request, and is returned as a static image.
        /// https://developers.google.com/maps/documentation/streetview/intro
        /// </summary>
        public static StreetViewApi StreetView => new();

        /// <summary>
        /// The Google Static Maps API lets you embed a Google Maps image on your web page without requiring JavaScript or any dynamic page loading.
        /// The Google Static Maps API service creates your map based on URL parameters sent through a standard HTTP request and returns the map as an image
        /// you can display on your web page.
        /// https://developers.google.com/maps/documentation/static-maps/intro
        /// </summary>
        public static StaticMapsApi StaticMaps => new();
    }

    public partial class GoogleMaps
    {
        /// <summary>
        ///
        /// </summary>
        public sealed class AddressGeocodeApi : HttpEngine<AddressGeocodeRequest, GeocodeResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public AddressGeocodeApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public AddressGeocodeApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class DirectionsApi : HttpEngine<DirectionsRequest, DirectionsResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public DirectionsApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public DirectionsApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class DistanceMatrixApi : HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public DistanceMatrixApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public DistanceMatrixApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class ElevationApi : HttpEngine<ElevationRequest, ElevationResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public ElevationApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public ElevationApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class GeolocationApi : HttpEngine<GeolocationRequest, GeolocationResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public GeolocationApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public GeolocationApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class NearestRoadsApi : HttpEngine<NearestRoadsRequest, NearestRoadsResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public NearestRoadsApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public NearestRoadsApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class LocationGeocodeApi : HttpEngine<LocationGeocodeRequest, GeocodeResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public LocationGeocodeApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public LocationGeocodeApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class PlaceGeoCodeApi : HttpEngine<PlaceGeocodeRequest, GeocodeResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public PlaceGeoCodeApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public PlaceGeoCodeApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class PlusCodeGeocodeApi : HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public PlusCodeGeocodeApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public PlusCodeGeocodeApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class SnapToRoadApi : HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public SnapToRoadApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public SnapToRoadApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class SpeedLimitsApi : HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public SpeedLimitsApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public SpeedLimitsApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class StreetViewApi : HttpEngine<StreetViewRequest, StreetViewResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public StreetViewApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public StreetViewApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class StaticMapsApi : HttpEngine<StaticMapsRequest, StaticMapsResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public StaticMapsApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public StaticMapsApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class TimeZoneApi : HttpEngine<TimeZoneRequest, TimeZoneResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public TimeZoneApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public TimeZoneApi(HttpClient client) : base(client) { }
        }
    }

}