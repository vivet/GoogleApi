using GoogleApi.Engine;
using GoogleApi.Entities.Places.PlacesAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesAutoComplete.Response;
using GoogleApi.Entities.Places.PlacesDetails.Request;
using GoogleApi.Entities.Places.PlacesDetails.Response;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Response;

namespace GoogleApi
{
    /// <summary>
    /// Methods to access Google Places Api: 
    /// Documentation: https://developers.google.com/places
    /// https://developers.google.com/places/web-service/intro
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
                return EngineFacade<PlacesDetailsRequest, PlacesDetailsResponse>._instance;
            }
        }
        /// <summary>
        /// Perform places autocomplete operations.
        /// </summary>
        public static EngineFacade<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse> AutoComplete
        {
            get
            {
                return EngineFacade<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>._instance;
            }
        }
        /// <summary>
        /// Perform places query autocomplete operations.
        /// </summary>
        public static EngineFacade<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse> QueryAutoComplete
        {
            get
            {
                return EngineFacade<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>._instance;
            }
        }
    }
}