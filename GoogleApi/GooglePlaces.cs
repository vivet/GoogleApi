using GoogleApi.Engine;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.PlacesAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesAutoComplete.Response;
using GoogleApi.Entities.Places.PlacesDetails.Request;
using GoogleApi.Entities.Places.PlacesDetails.Response;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Response;
using GoogleApi.Entities.Places.PlacesSearch.Request;
using GoogleApi.Entities.Places.PlacesSearch.Response;

namespace GoogleApi
{
    /// <summary>
    /// Methods to access Google Places Api: https://developers.google.com/places/documentation/
    /// </summary>
    public class GooglePlaces
    {
        /// <summary>
        /// Perform places details search operations.
        /// </summary>
        public static EngineFacade<PlacesDetailsRequest, PlacesDetailsResponse> Details
        {
            get
            {
                return EngineFacade<PlacesDetailsRequest, PlacesDetailsResponse>.Instance();
            }
        }
        
        /// <summary>
        /// Perform places autocomplete operations.
        /// </summary>
        public static EngineFacade<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse> AutoComplete
        {
            get
            {
                return EngineFacade<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>.Instance();
            }
        }
        
        /// <summary>
        /// Perform places query autocomplete operations.
        /// </summary>
        public static EngineFacade<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse> QueryAutoComplete
        {
            get
            {
                return EngineFacade<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>.Instance();
            }
        }

        /// <summary>
        /// Performs Places Nearby query
        /// </summary>
        public static EngineFacade<PlacesNearbySearchRequest, PlacesNearbySearchResponse> NearBy
        {
            get
            {
                return EngineFacade<PlacesNearbySearchRequest, PlacesNearbySearchResponse>.Instance();
            }
        }

        /// <summary>
        /// Performs Places Radar query
        /// </summary>
        public static EngineFacade<PlacesRadarSearchRequest, PlacesRadarSearchResponse> Radar
        {
            get
            {
                return EngineFacade<PlacesRadarSearchRequest, PlacesRadarSearchResponse>.Instance();
            }
        }

        /// <summary>
        /// Performs Places Test query
        /// </summary>
        public static EngineFacade<PlacesTextSearchRequest, PlacesTextSearchResponse> Text
        {
            get
            {
                return EngineFacade<PlacesTextSearchRequest, PlacesTextSearchResponse>.Instance();
            }
        }
    }
}