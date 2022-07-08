using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GoogleApi;

/// <summary>
///   Provide a default global httpClient and a factory a factory method
/// </summary>
public static class HttpClientFactory
{
    /// <summary>
    /// Proxy property that will be used for all requests.
    /// </summary>
    public static IWebProxy Proxy { get; set; }

    /// <summary>
    /// Create Default Http Client.
    /// </summary>
    /// <param name="webProxy">The <see cref="IWebProxy"/> (optional).</param>
    /// <param name="httpMessageHandler">The <see cref="HttpMessageHandler"/>.</param>
    /// <returns>The <see cref="HttpClient"/>.</returns>
    public static HttpClient CreateDefaultHttpClient(IWebProxy webProxy = null, HttpMessageHandler httpMessageHandler = null)
    {
        Proxy ??= HttpClientFactory.Proxy;
        httpMessageHandler ??= HttpClientFactory.GetDefaultHttpClientHandler(webProxy);

        var httpClient = new HttpClient(httpMessageHandler);

        HttpClientFactory.ConfigureDefaultHttpClient(httpClient);

        return httpClient;
    }

    /// <summary>
    /// Configure Default Http Client.
    /// </summary>
    /// <param name="httpClient"></param>
    public static void ConfigureDefaultHttpClient(HttpClient httpClient)
    {
        if (httpClient == null)
            throw new ArgumentNullException(nameof(httpClient));

        httpClient.Timeout = TimeSpan.FromSeconds(30);

        httpClient.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <summary>
    /// Get Default Http Client Handler.
    /// </summary>
    /// <returns>The <see cref="HttpMessageHandler"/>.</returns>
    public static HttpClientHandler GetDefaultHttpClientHandler(IWebProxy webProxy = null)
    {
        var httpClientHandler = new HttpClientHandler
        {
            Proxy = webProxy
        };

        if (httpClientHandler.SupportsAutomaticDecompression)
        {
            httpClientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        }

        return httpClientHandler;
    }
}