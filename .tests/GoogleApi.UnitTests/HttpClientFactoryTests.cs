using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests;

[TestClass]
public class HttpClientFactoryTests
{
    [TestMethod]
    public void CreateDefaultHttpClientTest()
    {
        var httpClient = HttpClientFactory.CreateDefaultHttpClient();
        var defaultHttpClientHandler = HttpClientFactory.GetDefaultHttpClientHandler();

        var expected = new MediaTypeWithQualityHeaderValue("application/json");

        Assert.IsTrue(httpClient.DefaultRequestHeaders.Accept.Contains(expected));
        Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(30));

        var hasGZip = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.GZip);
        Assert.IsTrue(hasGZip);

        var hasDeflate = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.Deflate);
        Assert.IsTrue(hasDeflate);
    }

    [TestMethod]
    public void CreateDefaultHttpClientWhenWebProxyTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void ConfigureDefaultHttpClientTest()
    {
        var httpClient = new HttpClient();

        HttpClientFactory.ConfigureDefaultHttpClient(httpClient);

        var expected = new MediaTypeWithQualityHeaderValue("application/json");

        Assert.IsTrue(httpClient.DefaultRequestHeaders.Accept.Contains(expected));
        Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(30));
    }

    [TestMethod]
    public void GetDefaultHttpClientHandlerTest()
    {
        var defaultHttpClientHandler = HttpClientFactory.GetDefaultHttpClientHandler();

        Assert.IsInstanceOfType<HttpClientHandler>(defaultHttpClientHandler);

        var hasGZip = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.GZip);
        Assert.IsTrue(hasGZip);

        var hasDeflate = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.Deflate);
        Assert.IsTrue(hasDeflate);
    }
}