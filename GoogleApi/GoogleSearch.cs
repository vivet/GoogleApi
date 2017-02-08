using GoogleApi.Engine;
using GoogleApi.Entities.Search.Common.Response;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Entities.Search.Site.Request;
using GoogleApi.Entities.Search.Web.Request;

namespace GoogleApi
{
    /// <summary>
    /// The JSON/Atom Custom Search API lets you develop websites and applications to retrieve and display search results from Google Custom Search programmatically. 
    /// With this API, you can use RESTful requests to get either web search or image search results in JSON or Atom format.
    /// Documentation: https://developers.google.com/custom-search/json-api/v1/overview    
    /// </summary>
    public class GoogleSearch
    {
        /// <summary>
        /// Web Search.
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI. 
        /// You pass in the details of the search request as query parameters. 
        /// </summary>
        public static FacadeEngine<WebSearchRequest, BaseSearchResponse> WebSearch => FacadeEngine<WebSearchRequest, BaseSearchResponse>.instance;

        /// <summary>
        /// Site Search.
        /// Searches using a search engine created with the Google Control Panel.
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI. 
        /// You pass in the details of the search request as query parameters. 
        /// </summary>
        public static FacadeEngine<SiteSearchRequest, BaseSearchResponse> SiteSearch => FacadeEngine<SiteSearchRequest, BaseSearchResponse>.instance;

        /// <summary>
        /// Image Search        
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
        /// You pass in the details of the search request as query parameters. 
        /// </summary>
        public static FacadeEngine<ImageSearchRequest, BaseSearchResponse> ImageSearch => FacadeEngine<ImageSearchRequest, BaseSearchResponse>.instance;
    }
}