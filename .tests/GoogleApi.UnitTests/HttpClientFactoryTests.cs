using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace GoogleApi.UnitTests;

[TestFixture]
public class HttpClientFactoryTests
{
    [Test]
    public void CreateDefaultHttpClientTest()
    {
        var httpClient = HttpClientFactory.CreateDefaultHttpClient();
        var defaultHttpClientHandler = HttpClientFactory.GetDefaultHttpClientHandler();

        var expected = new MediaTypeWithQualityHeaderValue("application/json");
        Assert.Contains(expected, httpClient.DefaultRequestHeaders.Accept.ToArray());

        Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(30));

        var hasGZip = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.GZip);
        Assert.True(hasGZip);

        var hasDeflate = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.Deflate);
        Assert.True(hasDeflate);

//#if NETCOREAPP3_1_OR_GREATER
//            var hasGSslProtocolsNone = defaultHttpClientHandler.SslProtocols.HasFlag(SslProtocols.None);
//            Assert.True(hasGSslProtocolsNone);
//#endif
    }

    [Test]
    public void CreateDefaultHttpClientWhenWebProxyTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void ConfigureDefaultHttpClientTest()
    {
        var httpClient = new HttpClient();

        HttpClientFactory.ConfigureDefaultHttpClient(httpClient);

        var expected = new MediaTypeWithQualityHeaderValue("application/json");
        Assert.Contains(expected, httpClient.DefaultRequestHeaders.Accept.ToArray());

        Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(30));
    }

    [Test]
    public void GetDefaultHttpClientHandlerTest()
    {
        var defaultHttpClientHandler = HttpClientFactory.GetDefaultHttpClientHandler();

        Assert.IsInstanceOf<HttpClientHandler>(defaultHttpClientHandler);

        var hasGZip = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.GZip);
        Assert.True(hasGZip);

        var hasDeflate = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.Deflate);
        Assert.True(hasDeflate);

//#if NETCOREAPP3_1_OR_GREATER
//            var hasGSslProtocolsNone = defaultHttpClientHandler.SslProtocols.HasFlag(SslProtocols.None);
//            Assert.True(hasGSslProtocolsNone);
//#endif
    }
}