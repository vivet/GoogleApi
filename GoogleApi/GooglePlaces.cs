using GoogleApi.Engine;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.Add.Response;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Response;
using GoogleApi.Entities.Places.Delete.Request;
using GoogleApi.Entities.Places.Delete.Response;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Search.Radar.Request;
using GoogleApi.Entities.Places.Search.Radar.Response;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;

namespace GoogleApi
{
    /// <summary>
    /// Methods to access Google Places Api: 
    /// https://developers.google.com/places/web-service/intro
    /// </summary>
    public class GooglePlaces
    {
        /// <summary>
        /// The Place Photo service, part of the Google Places API Web Service, is a read-only API that allows you to add high quality photographic content to your application. 
        /// The Place Photo service gives you access to the millions of photos stored in the Places and Google+ Local database. When you get place information using a Place Details request, 
        /// photo references will be returned for relevant photographic content. The Nearby Search and Text Search requests also return a single photo reference per place, when relevant. 
        /// Using the Photo service you can then access the referenced photos and resize the image to the optimal size for your application.
        /// </summary>
        public static FacadeEngine<PlacesPhotosRequest, PlacesPhotosResponse> Photos
            => FacadeEngine<PlacesPhotosRequest, PlacesPhotosResponse>.instance;

        /// <summary>
        /// The Google Places API Text Search Service is a web service that returns information about a set of places based on a string — for example "pizza in New York" or "shoe stores near Ottawa". 
        /// The service responds with a list of places matching the text string and any location bias that has been set. 
        /// The search response will include a list of places, you can send a Place Details request for more information about any of the places in the response.
        /// https://developers.google.com/places/web-service/search
        /// </summary>
        public static FacadeEngine<PlacesTextSearchRequest, PlacesTextSearchResponse> TextSearch
            => FacadeEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>.instance;

        /// <summary>
        /// The Google Places API Radar Search Service allows you to search for up to 200 places at once, but with less detail than is typically returned from a Text Search or Nearby Search request. 
        /// With Radar Search, you can create applications that help users identify specific areas of interest within a geographic area.
        /// https://developers.google.com/places/web-service/search
        /// </summary>
        public static FacadeEngine<PlacesRadarSearchRequest, PlacesRadarSearchResponse> RadarSearch
            => FacadeEngine<PlacesRadarSearchRequest, PlacesRadarSearchResponse>.instance;

        /// <summary>
        /// A Nearby Search lets you search for places within a specified area. 
        /// You can refine your search request by supplying keywords or specifying the type of place you are searching for
        /// https://developers.google.com/places/web-service/search
        /// </summary>
        public static FacadeEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse> NearBySearch
            => FacadeEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>.instance;

        /// <summary>
        /// By adding a place, you can supplement the data in the Google Maps database with data from your application. This allows you to:
        /// Instantly update the data in Google's database for your users.
        /// Submit new places to a moderation queue for addition to the Google places database.
        /// Differentiate your application from other apps with similar functionality.
        /// Create applications that are targeted to a specific user base or geographic location.
        /// Influence the results of a Places Search issued from your application.
        /// https://developers.google.com/places/web-service/add-place
        /// </summary>
        public static FacadeEngine<PlacesAddRequest, PlacesAddResponse> Add
            => FacadeEngine<PlacesAddRequest, PlacesAddResponse>.instance;

        /// <summary>
        /// A place can only be deleted if:
        /// The place was added by the application that is requesting the deletion.
        /// The place add request has not successfully passed through the Google Maps moderation process, and the place is therefore visible only to the application that added it.
        /// If you try to delete a place that does not meet these criteria, the API will return a REQUEST_DENIED status code.
        /// https://developers.google.com/places/web-service/add-place
        /// </summary>
        public static FacadeEngine<PlacesDeleteRequest, PlacesDeleteResponse> Delete
            => FacadeEngine<PlacesDeleteRequest, PlacesDeleteResponse>.instance;

        /// <summary>
        /// Once you have a place_id from a Place Search, you can request more details about a particular establishment or point of interest by initiating a Place Details request. 
        /// A Place Details request returns more comprehensive information about the indicated place such as its complete address, phone number, user rating and reviews.
        /// https://developers.google.com/places/web-service/details
        /// </summary>
        public static FacadeEngine<PlacesDetailsRequest, PlacesDetailsResponse> Details
            => FacadeEngine<PlacesDetailsRequest, PlacesDetailsResponse>.instance;

        /// <summary>
        /// The Query Autocomplete service can be used to provide a query prediction for text-based geographic searches, by returning suggested queries as you type.
        /// https://developers.google.com/places/web-service/query
        /// </summary>
        public static FacadeEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse> AutoComplete
            => FacadeEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>.instance;

        /// <summary>
        /// The Place Autocomplete service is a web service that returns place predictions in response to an HTTP request. 
        /// The request specifies a textual search string and optional geographic bounds. The service can be used to provide autocomplete functionality for text-based geographic searches, 
        /// by returning places such as businesses, addresses and points of interest as a user types.
        /// https://developers.google.com/places/web-service/autocomplete
        /// </summary>
        public static FacadeEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse> QueryAutoComplete
            => FacadeEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>.instance;
    }
}