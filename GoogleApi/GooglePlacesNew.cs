using System.Net.Http;
using GoogleApi.Entities.PlacesNew.AutoComplete.Request;
using GoogleApi.Entities.PlacesNew.AutoComplete.Response;
using GoogleApi.Entities.PlacesNew.Details.Request;
using GoogleApi.Entities.PlacesNew.Details.Response;
using GoogleApi.Entities.PlacesNew.Photos.Request;
using GoogleApi.Entities.PlacesNew.Photos.Response;
using GoogleApi.Entities.PlacesNew.Search.NearBy.Request;
using GoogleApi.Entities.PlacesNew.Search.NearBy.Response;
using GoogleApi.Entities.PlacesNew.Search.Text.Request;
using GoogleApi.Entities.PlacesNew.Search.Text.Response;
using GoogleApi.Interfaces.PlacesNew;
using GoogleApi.Interfaces.PlacesNew.Search;

namespace GoogleApi;

/// <summary>
/// Methods to access Google Places New Api:
/// https://developers.google.com/maps/documentation/places/web-service/op-overview
/// </summary>
public partial class GooglePlacesNew
{
    /// <summary>
    /// Once you have a place ID, you can request more details about a particular establishment or point of interest by initiating a Place Details (New) request.
    /// A Place Details (New) request returns more comprehensive information about the indicated place
    /// such as its complete address, phone number, user rating and reviews.
    /// https://developers.google.com/maps/documentation/places/web-service/place-details
    /// </summary>
    public static DetailsNewApi DetailsNew => new();

    /// <summary>
    /// The Autocomplete (New) service is a web service that returns place predictions and query predictions in response to an HTTP request.
    /// In the request, specify a text search string and geographic bounds that controls the search area.
    /// https://developers.google.com/maps/documentation/places/web-service/place-autocomplete
    /// </summary>
    public static AutoCompleteNewApi AutoCompleteNew => new();

    /// <summary>
    /// Search (nested class).
    /// </summary>
    public static partial class Search
    {
        /// <summary>
        /// Text Search (New) returns information about a set of places based on a string 
        /// for example, "pizza in New York" or "shoe stores near Ottawa" or "123 Main Street".
        /// The service responds with a list of places matching the text string and any location bias that has been set.
        /// https://developers.google.com/maps/documentation/places/web-service/text-search
        /// </summary>
        public static TextSearchNewApi TextSearchNew => new();

        /// <summary>
        /// A Nearby Search (New) request takes one or more place types, and returns a list of matching places within the specified area.
        /// A field mask specifying one or more data types is required. Nearby Search (New) only supports POST requests.
        /// https://developers.google.com/maps/documentation/places/web-service/nearby-search
        /// https://developers.google.com/maps/documentation/places/web-service/place-photos#skiphttpredirect
        /// </summary>
        public static NearBySearchNewApi NearBySearchNew => new();
    }

    /// <summary>
    /// Search (nested class).
    /// </summary>
    public static partial class Photos
    {
        /// <summary>
        /// The Place Photo (New) service is a read-only API that allows you to add high quality photographic content to your application.
        /// The Place Photo service gives you access to the millions of photos stored in the Places database.
        /// When you get place information using a Place Details, Nearby Search, or Text Search request,
        /// you can also request photo resources for relevant photographic content.Using the Photo service,
        /// you can then access the referenced photos and resize the image to the optimal size for your application.
        /// https://developers.google.com/maps/documentation/places/web-service/place-photos
        /// </summary>
        public static PhotosNewApi PhotosNew => new();

        /// <summary>
        /// The Place Photo (New) service is a read-only API that allows you to add high quality photographic content to your application.
        /// The Place Photo service gives you access to the millions of photos stored in the Places database.
        /// When you get place information using a Place Details, Nearby Search, or Text Search request,
        /// you can also request photo resources for relevant photographic content.Using the Photo service,
        /// you can then access the referenced photos and resize the image to the optimal size for your application.
        /// https://developers.google.com/maps/documentation/places/web-service/place-photos
        /// </summary>
        public static PhotosNewSkipHttpRedirectApi PhotosNewSkipHttpRedirect => new();
    }
}

public partial class GooglePlacesNew
{
    /// <summary>
    /// Auto Complete Api.
    /// </summary>
    public sealed class AutoCompleteNewApi : HttpEngine<PlacesNewAutoCompleteRequest, PlacesNewAutoCompleteResponse>, IAutoCompleteNewApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AutoCompleteNewApi()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public AutoCompleteNewApi(HttpClient httpClient) 
            : base(httpClient)
        {
        }
    }

    /// <summary>
    /// Details Api.
    /// </summary>
    public sealed class DetailsNewApi : HttpEngine<PlacesNewDetailsRequest, PlacesNewDetailsResponse>, IDetailsNewApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DetailsNewApi()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public DetailsNewApi(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }

    /// <summary>
    /// Photos.
    /// </summary>
    public static partial class Photos
    {
        /// <summary>
        /// Photos Api.
        /// </summary>
        public sealed class PhotosNewApi : HttpEngine<PlacesNewPhotosRequest, PlacesNewPhotosResponse>, IPhotosNewApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public PhotosNewApi()
            {
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public PhotosNewApi(HttpClient httpClient)
                : base(httpClient)
            {
            }
        }

        /// <summary>
        /// Photos Api.
        /// </summary>
        public sealed class PhotosNewSkipHttpRedirectApi : HttpEngine<PlacesNewPhotosSkipHttpRedirectRequest, PlacesNewPhotosSkipHttpRedirectResponse>, IPhotosNewSkipHttpRedirectApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public PhotosNewSkipHttpRedirectApi()
            {
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public PhotosNewSkipHttpRedirectApi(HttpClient httpClient)
                : base(httpClient)
            {
            }
        }
    }

    public static partial class Search
    {
        /// <summary>
        /// Near By Search Api.
        /// </summary>
        public sealed class NearBySearchNewApi : HttpEngine<PlacesNewNearBySearchRequest, PlacesNewNearbySearchResponse>, INearBySearchNewApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public NearBySearchNewApi()
            {
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public NearBySearchNewApi(HttpClient httpClient)
                : base(httpClient)
            {
            }
        }

        /// <summary>
        /// Text Search Api
        /// </summary>
        public sealed class TextSearchNewApi : HttpEngine<PlacesNewTextSearchRequest, PlacesNewTextSearchResponse>, ITextSearchNewApi
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public TextSearchNewApi()
            {
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public TextSearchNewApi(HttpClient httpClient)
                : base(httpClient)
            {
            }
        }
    }
}
