using GoogleApi.Entities.Maps.Directions.Request;
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
using GoogleApi.Entities.Maps.AddressValidation.Request;
using GoogleApi.Entities.Maps.AddressValidation.Response;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using GoogleApi.Entities.Maps.Routes.Directions.Response;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using GoogleApi.Entities.Maps.Routes.Matrix.Response;
using GoogleApi.Interfaces.Maps;
using GoogleApi.Interfaces.Maps.Roads;
using GoogleApi.Interfaces.Maps.Geocode;
using GoogleApi.Interfaces.Maps.Routes.Directions;
using GoogleApi.Interfaces.Maps.Routes.Matrix;

namespace GoogleApi;

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
    /// The Google Maps Geolocation API returns a location and accuracy radius based on information about cell towers and WiFi nodes that the mobile httpClient can detect.
    /// This document describes the protocol used to send this data to the server and to return a response to the httpClient.
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

    /// <summary>
    /// The Address Validation API is a service that accepts an address. It identifies address components and validates them.
    /// It also standardizes the address for mailing and finds the best known latitude/longitude coordinates for it.
    /// Optionally, for addresses in the United States and Puerto Rico, you can enable the Coding Accuracy Support System (CASS™).
    /// https://developers.google.com/maps/documentation/address-validation
    /// </summary>
    public static AddressValidationApi AddressValidation => new();

    /// <summary>
    /// Geocode (nested class).
    /// </summary>
    public static partial class Geocode
    {
        /// <summary>
        /// Geocoding is the process of converting addresses (like "1600 Amphitheatre Parkway, Mountain View, CA") into
        /// geographic coordinates (like latitude 37.423021 and longitude -122.083739), which you can use to place markers on a map, or position the map.
        /// This is the process of converting a place id into a address.
        /// </summary>
        public static PlaceGeocodeApi PlaceGeocode => new();

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
        /// </summary>
        public static PlusCodeGeocodeApi PlusCodeGeocode => new();
    }

    /// <summary>
    /// Roads (nested class).
    /// </summary>
    public static partial class Roads
    {
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
    }

    /// <summary>
    /// Routes (nested class).
    /// </summary>
    public static partial class Routes
    {
        /// <summary>
        /// Returns the primary route along with optional alternate routes, given a set of terminal and intermediate waypoints.
        /// https://developers.google.com/maps/documentation/routes/reference/rest/v2/TopLevel/computeRoutes
        /// </summary>
        public static RoutesDirectionsApi Direcions => new();

        /// <summary>
        /// Takes in a list of origins and destinations and returns a stream containing route information for each combination of origin and destination.
        /// https://developers.google.com/maps/documentation/routes/reference/rest/v2/TopLevel/computeRouteMatrix
        /// </summary>
        public static RoutesMatrixApi Matrix => new();
    }
}

public partial class GoogleMaps
{
    /// <summary>
    /// Directions Api.
    /// </summary>
    public sealed class DirectionsApi : HttpEngine<DirectionsRequest, DirectionsResponse>, IDirectionsApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DirectionsApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public DirectionsApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Distance Matrix Api.
    /// </summary>
    public sealed class DistanceMatrixApi : HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>, IDistanceMatrixApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DistanceMatrixApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public DistanceMatrixApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Elevation Api.
    /// </summary>
    public sealed class ElevationApi : HttpEngine<ElevationRequest, ElevationResponse>, IElevationApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ElevationApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public ElevationApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Geolocation Api.
    /// </summary>
    public sealed class GeolocationApi : HttpEngine<GeolocationRequest, GeolocationResponse>, IGeolocationApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GeolocationApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public GeolocationApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Street View Api.
    /// </summary>
    public sealed class StreetViewApi : HttpEngine<StreetViewRequest, StreetViewResponse>, IStreetViewApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public StreetViewApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public StreetViewApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Static Maps Api.
    /// </summary>
    public sealed class StaticMapsApi : HttpEngine<StaticMapsRequest, StaticMapsResponse>, IStaticMapsApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public StaticMapsApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public StaticMapsApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Time Zone Api.
    /// </summary>
    public sealed class TimeZoneApi : HttpEngine<TimeZoneRequest, TimeZoneResponse>, ITimeZoneApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TimeZoneApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public TimeZoneApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Address Validation Api.
    /// </summary>
    public sealed class AddressValidationApi : HttpEngine<AddressValidationRequest, AddressValidationResponse>, IAddressValidationApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AddressValidationApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public AddressValidationApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    public static partial class Geocode
    {
        /// <summary>
        /// Address Geocode Api.
        /// </summary>
        public sealed class AddressGeocodeApi : HttpEngine<AddressGeocodeRequest, GeocodeResponse>, IAddressGeocodeApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public AddressGeocodeApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public AddressGeocodeApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Location Geocode Api.
        /// </summary>
        public sealed class LocationGeocodeApi : HttpEngine<LocationGeocodeRequest, GeocodeResponse>, ILocationGeocodeApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public LocationGeocodeApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public LocationGeocodeApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Place Geocode Api.
        /// </summary>
        public sealed class PlaceGeocodeApi : HttpEngine<PlaceGeocodeRequest, GeocodeResponse>, IPlaceGeocodeApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public PlaceGeocodeApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public PlaceGeocodeApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Plus Code Geocode Api.
        /// </summary>
        public sealed class PlusCodeGeocodeApi : HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>, IPlusCodeGeocodeApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public PlusCodeGeocodeApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public PlusCodeGeocodeApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }
    }

    public static partial class Roads
    {
        /// <summary>
        /// Snap To Road Api.
        /// </summary>
        public sealed class SnapToRoadApi : HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>, ISnapToRoadApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public SnapToRoadApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public SnapToRoadApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Nearest Roads Api.
        /// </summary>
        public sealed class NearestRoadsApi : HttpEngine<NearestRoadsRequest, NearestRoadsResponse>, INearestRoadsApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public NearestRoadsApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public NearestRoadsApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Speed Limits Api.
        /// </summary>
        public sealed class SpeedLimitsApi : HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>, ISpeedLimitsApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public SpeedLimitsApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public SpeedLimitsApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }
    }

    public static partial class Routes
    {
        /// <summary>
        /// Routes Directions Api.
        /// </summary>
        public sealed class RoutesDirectionsApi : HttpEngine<RoutesDirectionsRequest, RoutesDirectionsResponse>, IRoutesDirectionsApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public RoutesDirectionsApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public RoutesDirectionsApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Routes Matrix Api.
        /// </summary>
        public sealed class RoutesMatrixApi : HttpEngine<RoutesMatrixRequest, RoutesMatrixResponse>, IRoutesMatrixApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public RoutesMatrixApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public RoutesMatrixApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }
    }
}