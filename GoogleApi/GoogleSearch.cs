using GoogleApi.Entities.Search.Common.Response;
using GoogleApi.Entities.Search.Enterprise.Request;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Entities.Search.Web.Request;

namespace GoogleApi
{
    /// <summary>
    /// The JSON/Atom Custom Search API lets you develop websites and applications to retrieve and display search results from Google Custom Search programmatically. 
    /// Documentation: https://developers.google.com/custom-search/docs/overview / 
    /// With this API, you can use RESTful requests to get either web search or image search results in JSON or Atom format.
    /// Documentation: https://developers.google.com/custom-search/json-api/v1/overview
    /// The easiest way to get started with Google Custom Search is to create a basic search engine using the Control Panel.
    /// You can then download the engine's XML files and modify them to add futher customizations. 
    /// There are two ways of creating a Custom Search Engine (CSE): 
    /// - Using the Control Panel (https://cse.google.com/manage/all) 
    /// - Or creating an XML file with the definition of the engine (https://developers.google.com/custom-search/docs/basics)
    /// There are also two external documents that are helpful resources for using this API: 
    /// - Google WebSearch Protocol(XML): The JSON/Atom Custom Search API provides a subset of the functionality provided by the XML API, but it instead returns data in JSON or Atom format.
    /// - OpenSearch 1.1 Specification: This API uses the OpenSearch specification to describe the search engine and provide data regarding the results.Because of this, you can write your code so that it can support any OpenSearch engine, not just Google's custom search engine. There is currently no other JSON implementation of OpenSearch, so all the examples in the OpenSearch spec are in XML.
    /// </summary>
    public class GoogleSearch
    {
        /// <summary>
        /// Web Search (free).
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI. 
        /// You pass in the details of the search request as query parameters. 
        /// </summary>
        public static FacadeEngine<WebSearchRequest, BaseSearchResponse> WebSearch => FacadeEngine<WebSearchRequest, BaseSearchResponse>.instance;

        /// <summary>
        /// Enterprise Search (paid).
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI. 
        /// You pass in the details of the search request as query parameters. 
        /// </summary>
        public static FacadeEngine<EnterpriseSearchRequest, BaseSearchResponse> EnterpriseSearch => FacadeEngine<EnterpriseSearchRequest, BaseSearchResponse>.instance;

        /// <summary>
        /// Image Search (free).
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
        /// You pass in the details of the search request as query parameters. 
        /// </summary>
        public static FacadeEngine<ImageSearchRequest, BaseSearchResponse> ImageSearch => FacadeEngine<ImageSearchRequest, BaseSearchResponse>.instance;
    }
}