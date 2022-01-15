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
    internal static readonly HttpClient GlobalHttpClient = CreateDefault();

    /// <summary>
    /// Proxy property that will be used for all requests.
    /// </summary>
    public static IWebProxy Proxy { get; set; }

    /// <summary>
    ///  Default Implementation to generate and get an HttpClient
    /// </summary>
    public static HttpClient CreateDefault(IWebProxy proxy = null, HttpMessageHandler innerHandler = null)
    {
        innerHandler ??= GetPrimaryHandler(null);

        proxy ??= HttpClientFactory.Proxy;

        if (proxy != null && innerHandler is HttpClientHandler handler)
        {
            handler.Proxy = proxy;
        }

        var client = new HttpClient(innerHandler);

        ConfigureDefaultClient(null, client);

        return client;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="_"></param>
    /// <param name="c"></param>
    public static void ConfigureDefaultClient(IServiceProvider _, HttpClient c)
    {
        c.Timeout = TimeSpan.FromSeconds(30);
        const string MimeTypeJson = "application/json";
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypeJson));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static HttpMessageHandler GetPrimaryHandler(IServiceProvider _)
    {
        var handler = new HttpClientHandler();

        if (handler.SupportsAutomaticDecompression)
        {
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        }

        //NOTE:https://docs.microsoft.com/en-us/dotnet/api/system.security.authentication.sslprotocols?view=net-6.0#fields
        // None: | Allows the operating system to choose the best protocol to use, and to block protocols that are not secure.
        //       | Unless your app has a specific reason not to, you should use this field.
        handler.SslProtocols = System.Security.Authentication.SslProtocols.None;

        return handler;
    }
}