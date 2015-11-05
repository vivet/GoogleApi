using GoogleApi.Engine;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Elevation.Response;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geocode.Response;
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
		/// Perform geocoding and reverse geocoding operations.
		/// </summary>
		public static EngineFacade<GeocodingRequest, GeocodingResponse> Geocode
		{
			get
			{
				return EngineFacade<GeocodingRequest, GeocodingResponse>._instance;
			}
		}
		/// <summary>
		/// Perform directions operations.
		/// </summary>
		public static EngineFacade<DirectionsRequest, DirectionsResponse> Directions
		{
			get
			{
				return EngineFacade<DirectionsRequest, DirectionsResponse>._instance;
			}
		}
		/// <summary>
		/// Perform elevation operations.
		/// </summary>
		public static EngineFacade<ElevationRequest, ElevationResponse> Elevation
		{
			get
			{
				return EngineFacade<ElevationRequest, ElevationResponse>._instance;
			}
		}
        /// <summary>
        /// Perform places details operations.
        /// </summary>
        public static EngineFacade<DistanceMatrixRequest, DistanceMatrixResponse> DistanceMatrix
        {
            get
            {
                return EngineFacade<DistanceMatrixRequest, DistanceMatrixResponse>._instance;
            }
        }
        /// <summary>
        /// The Google Maps Time Zone API provides a simple interface to request the time zone for a 
        /// location on the earth, as well as that location's time offset from UTC.
        /// https://developers.google.com/maps/documentation/timezone/intro
        /// </summary>
        public static EngineFacade<TimeZoneRequest, TimeZoneResponse> TimeZone
        {
            get
            {
                return EngineFacade<TimeZoneRequest, TimeZoneResponse>._instance;
            }
        }
    }
}
