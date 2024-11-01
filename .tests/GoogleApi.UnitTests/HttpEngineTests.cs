using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoFixture;
using GoogleApi.Entities;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Converters.Factories;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Search.Common.Converters;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace GoogleApi.UnitTests;

[TestClass]
public sealed class HttpEngineTests
{
    private const string APPLICATION_JSON = "application/json";

    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new StringBooleanZeroOneJsonConverter(),
            new JsonStringEnumConverterFactory(),
            new SortExpressionJsonConverter()
        },
        ReferenceHandler = ReferenceHandler.Preserve,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    private readonly IFixture fixture = new Fixture();
    private readonly MockHttpMessageHandler mockHttpMessageHandler;

    public HttpEngineTests()
    {
        this.mockHttpMessageHandler = new MockHttpMessageHandler();

        this.fixture.Customize<DemoRequest>(x => x
            .With(y => y.Key, $"{Guid.NewGuid():N}")
            .With(y => y.ClientId, $"gme-{Guid.NewGuid():N}")
            .OmitAutoProperties());

        this.fixture.Customize<DemoPostRequest>(x => x
            .With(y => y.Key, $"{Guid.NewGuid():N}")
            .With(y => y.ClientId, $"gme-{Guid.NewGuid():N}")
            .OmitAutoProperties());

        this.fixture.Customize<DemoStreamRequest>(x => x
            .With(y => y.Key, $"{Guid.NewGuid():N}")
            .With(y => y.ClientId, $"gme-{Guid.NewGuid():N}")
            .OmitAutoProperties());
    }

    [TestMethod]
    public async Task QueryAsyncWhenOkTest()
    {
        var data = new
        {
            status = "OK",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var result = await httpEngine
            .QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task QueryPostWhenOk()
    {
        var data = new
        {
            status = "OK",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var demoPostHttpEngine = new DemoPostHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoPostRequest>();

        var result = await demoPostHttpEngine
            .QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task QueryStreamWhenOk()
    {
        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(_ => new StreamContent(new MemoryStream()));

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var demoStreamHttpEngine = new DemoStreamHttpEngine(httpClient);

        var request = fixture
            .Create<DemoStreamRequest>();

        var result = await demoStreamHttpEngine
            .QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
        Assert.IsNotNull(result.Buffer);
    }

    [TestMethod]
    public async Task QueryWhenNotFound()
    {
        var data = new
        {
            status = "NOT_FOUND",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var result = await httpEngine
            .QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.NotFound, result.Status);
    }

    [TestMethod]
    public async Task QueryWhenZeroResults()
    {
        var data = new
        {
            status = "ZERO_RESULTS",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var result = await httpEngine
            .QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.ZeroResults, result.Status);
    }

    [TestMethod]
    public async Task QueryWhenOverLimit()
    {
        var data = new
        {
            status = "OVER_QUERY_LIMIT",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));
        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(exception.Status, Status.OverQueryLimit);
    }

    [TestMethod]
    public async Task QueryWhenInvalidRequest()
    {
        var data = new
        {
            status = "INVALID_REQUEST",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var request = this.fixture
            .Create<DemoRequest>();

        var httpEngine = new DemoHttpEngine(httpClient);

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));
        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(exception.Status, Status.InvalidRequest);
    }

    [TestMethod]
    public async Task QueryWhenNoApiKey()
    {
        var data = new
        {
            status = "NO_API_KEY",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(exception.Status, Status.InvalidKey);
    }

    [TestMethod]
    public async Task QueryWhenRequestDenied()
    {
        var data = new
        {
            status = "REQUEST_DENIED",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.AreEqual(Status.RequestDenied, exception.Status);
    }

    [TestMethod]
    public async Task QueryWhenUnknownError()
    {
        var data = new
        {
            status = "UNKNOWN_ERROR",
            data = new { }
        };
        var response = JsonSerializer.Serialize(data, HttpEngineTests.jsonSerializerOptions);

        this.mockHttpMessageHandler
            .When("https://demo.googleapis.com/fakeservice/*")
            .Respond(HttpEngineTests.APPLICATION_JSON, response);

        var httpClient = this.mockHttpMessageHandler
            .ToHttpClient();

        var httpEngine = new DemoHttpEngine(httpClient);

        var request = this.fixture
            .Create<DemoRequest>();

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(Status.UnknownError, exception.Status);
    }

    #region Query Based
    private sealed class DemoHttpEngine(HttpClient client) : HttpEngine<DemoRequest, DemoResponse>(client);

    private sealed class DemoRequest : BaseRequest, IRequestQueryString
    {
        protected override string BaseUrl => "demo.googleapis.com/fakeservice/";
    }

    private sealed class DemoResponse : BaseResponse;
    #endregion

    #region Post Based
    private sealed class DemoPostHttpEngine(HttpClient client) : HttpEngine<DemoPostRequest, DemoPostResponse>(client);

    private sealed class DemoPostRequest : BaseRequest, IRequestJson
    {
        protected override string BaseUrl => "demo.googleapis.com/fakeservice/";
    }

    private sealed class DemoPostResponse : BaseResponse;
    #endregion

    #region Stream Based
    private sealed class DemoStreamHttpEngine(HttpClient client) : HttpEngine<DemoStreamRequest, DemoStreamResponse>(client);

    private sealed class DemoStreamRequest : BaseRequest, IRequestQueryString
    {
        protected override string BaseUrl => "demo.googleapis.com/fakeservice/";
    }

    private sealed class DemoStreamResponse : BaseResponseStream;
    #endregion
}