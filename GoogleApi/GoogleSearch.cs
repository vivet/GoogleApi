using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Entities.Search.Video.Channels.Request;
using GoogleApi.Entities.Search.Video.Channels.Response;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using GoogleApi.Entities.Search.Video.Playlists.Response;
using GoogleApi.Entities.Search.Video.Videos.Request;
using GoogleApi.Entities.Search.Video.Videos.Response;
using GoogleApi.Entities.Search.Web.Request;
using System.Net.Http;

namespace GoogleApi;

/// <summary>
/// The JSON/Atom Custom Search API lets you develop websites and applications to retrieve and display search results from Google Custom Search programmatically.
/// With this API, you can use RESTful requests to get either web search or image search results in JSON or Atom format.
/// https://developers.google.com/custom-search/docs/overview
/// By calling the API user issues requests against an existing instance of a Custom Search Engine.
/// Therefore, before using the API, you need to create one in the Control Panel (https://cse.google.com/cse/all).
/// Follow the tutorial to learn more about different configuration options. You can find the engine's ID in the Setup > Basics > Details section of the Control Panel.
/// REST Api: https://developers.google.com/custom-search/json-api/v1/overview
/// There are also two external documents that are helpful resources for using this API:
/// - Google WebSearch Protocol(XML): The JSON/Atom Custom Search API provides a subset of the functionality provided by the XML API, but it instead returns data in JSON or Atom format. (https://developers.google.com/custom-search/docs/xml_results)
/// - OpenSearch 1.1 Specification: This API uses the OpenSearch specification to describe the search engine and provide data regarding the results.Because of this, you can write your code so that it can support any OpenSearch engine, not just Google's custom search engine. There is currently no other JSON implementation of OpenSearch, so all the examples in the OpenSearch spec are in XML. (http://www.opensearch.org/Specifications/OpenSearch/1.1)
/// </summary>
public partial class GoogleSearch
{
    /// <summary>
    /// Web Search.
    /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
    /// You pass in the details of the search request as query parameters.
    /// </summary>
    public static WebSearchApi WebSearch => new();

    /// <summary>
    /// Image Search.
    /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
    /// You pass in the details of the search request as query parameters.
    /// </summary>
    public static ImageSearchApi ImageSearch => new();

    /// <summary>
    /// Video Search (nested class).
    /// </summary>
    public static partial class VideoSearch
    {
        /// <summary>
        /// Video Search.
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
        /// You pass in the details of the search request as query parameters.
        /// Docs: https://developers.google.com/youtube/v3/getting-started
        /// </summary>
        public static VideosApi Videos => new();

        /// <summary>
        /// Video Channel Search
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
        /// You pass in the details of the search request as query parameters.
        /// Docs: https://developers.google.com/youtube/v3/getting-started
        /// </summary>
        public static ChannelsApi Channels => new();

        /// <summary>
        /// Video Playlist Search
        /// You can retrieve results for a particular search by sending an HTTP GET request to its URI.
        /// You pass in the details of the search request as query parameters.
        /// Docs: https://developers.google.com/youtube/v3/getting-started
        /// </summary>
        public static PlaylistsApi Playlists => new();
    }
}

public partial class GoogleSearch
{
    /// <summary>
    /// Web Search Api.
    /// </summary>
    public sealed class WebSearchApi : HttpEngine<WebSearchRequest, BaseSearchResponse>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public WebSearchApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public WebSearchApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    /// <summary>
    /// Image Search Api.
    /// </summary>
    public sealed class ImageSearchApi : HttpEngine<ImageSearchRequest, BaseSearchResponse>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ImageSearchApi()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public ImageSearchApi(HttpClient httpClient)
            : base(httpClient)
        {

        }
    }

    public static partial class VideoSearch
    {
        /// <summary>
        /// Channels Api.
        /// </summary>
        public sealed class ChannelsApi : HttpEngine<ChannelSearchRequest, ChannelSearchResponse>
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public ChannelsApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public ChannelsApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Playlists Api.
        /// </summary>
        public sealed class PlaylistsApi : HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public PlaylistsApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public PlaylistsApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }

        /// <summary>
        /// Videos Api.
        /// </summary>
        public sealed class VideosApi : HttpEngine<VideoSearchRequest, VideoSearchResponse>
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public VideosApi()
            {

            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
            public VideosApi(HttpClient httpClient)
                : base(httpClient)
            {

            }
        }
    }
}