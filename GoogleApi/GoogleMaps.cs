using GoogleApi.Engine;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Elevation.Response;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geocode.Response;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Response;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;
using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Entities.Maps.TimeZone.Response;

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
    /// Documentation: https://developers.google.com/maps/web-services/overview
	/// </summary>
	public class GoogleMaps
	{
        /// <summary>
		/// Geocoding is the process of converting addresses (like "1600 Amphitheatre Parkway, Mountain View, CA") into geographic coordinates (like latitude 37.423021 and longitude -122.083739), 
		/// which you can use to place markers on a map, or position the map.
        /// Reverse geocoding is the process of converting geographic coordinates into a human-readable address. 
        /// The Google Maps Geocoding API's reverse geocoding service also lets you find the address for a given place ID.
        /// The Google Maps Geocoding API provides a direct way to access these services via an HTTP request.
        /// https://developers.google.com/maps/documentation/geocoding/intro
		/// </summary>
		public static EngineFacade<GeocodingRequest, GeocodingResponse> Geocode
		{
			get
			{
				return EngineFacade<GeocodingRequest, GeocodingResponse>._instance;
			}
		}

        /// <summary>
        /// The Google Maps Elevation API provides you a simple interface to query locations on the earth for elevation data. Additionally, 
        /// you may request sampled elevation data along paths, allowing you to calculate elevation changes along routes.
        /// https://developers.google.com/maps/documentation/elevation/intro
        /// </summary>
        public static EngineFacade<ElevationRequest, ElevationResponse> Elevation
        {
            get
            {
                return EngineFacade<ElevationRequest, ElevationResponse>._instance;
            }
        }
        
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
		public static EngineFacade<DirectionsRequest, DirectionsResponse> Directions
		{
			get
			{
				return EngineFacade<DirectionsRequest, DirectionsResponse>._instance;
			}
		}
        
        /// <summary>
        /// The Google Maps Distance Matrix API is a service that provides travel distance and time for a matrix of origins and destinations. 
        /// The information returned is based on the recommended route between start and end points, as calculated by the Google Maps API, 
        /// and consists of rows containing duration and distance values for each pair.
        /// https://developers.google.com/maps/documentation/distance-matrix/intro
        /// </summary>
        public static EngineFacade<DistanceMatrixRequest, DistanceMatrixResponse> DistanceMatrix
        {
            get
            {
                return EngineFacade<DistanceMatrixRequest, DistanceMatrixResponse>._instance;
            }
        }
        
        /// <summary>
        /// The Google Maps Time Zone API provides a simple interface to request the time zone for a location on the earth, as well as that location's time offset from UTC.
        /// The Google Maps Time Zone API provides time offset data for locations on the surface of the earth. 
        /// Requesting the time zone information for a specific Latitude/Longitude pair will return the name of that time zone, the time offset from UTC, and the Daylight Savings offset.
        /// https://developers.google.com/maps/documentation/timezone/intro
        /// </summary>
        public static EngineFacade<TimeZoneRequest, TimeZoneResponse> TimeZone
        {
            get
            {
                return EngineFacade<TimeZoneRequest, TimeZoneResponse>._instance;
            }
        }

        /// <summary>
        /// The snapToRoads method takes up to 100 GPS points collected along a route, and returns a similar set of data, 
        /// with the points snapped to the most likely roads the vehicle was traveling along. Optionally, you can request that the points be interpolated, 
        /// resulting in a path that smoothly follows the geometry of the road.
        /// https://developers.google.com/maps/documentation/roads/snap
        /// </summary>
        public static EngineFacade<SnapToRoadsRequest, SnapToRoadsResponse> SnapToRoad
        {
            get
            {
                return EngineFacade<SnapToRoadsRequest, SnapToRoadsResponse>._instance;
            }
        }

        /// <summary>
        /// The speedLimits method returns the posted speed limit for a given road segment. 
        /// In the case of road segments with variable speed limits, the default speed limit for the segment is returned.
        /// The accuracy of speed limit data returned by the Google Maps Roads API cannot be guaranteed. The speed limit data provided is not real-time, 
        /// and may be estimated, inaccurate, incomplete, and/or outdated. Inaccuracies in our data may be reported through the Google Map Maker service.
        /// https://developers.google.com/maps/documentation/roads/speed-limits
        /// </summary>
        public static EngineFacade<SpeedLimitsRequest, SpeedLimitsResponse> SpeedLimits
        {
            get
            {
                return EngineFacade<SpeedLimitsRequest, SpeedLimitsResponse>._instance;
            }
        }
    }
}
