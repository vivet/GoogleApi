using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoFixture;
using GoogleApi.Entities;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Search.Common.Converters;
using GoogleApi.Exceptions;
using NUnit.Framework;

using RichardSzalay.MockHttp;

namespace GoogleApi.UnitTests;

[TestFixture]
public sealed class HttpEngineTests
{
    private const string APPLICATION_JSON = "application/json";

    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = {
            new BooleanJsonConverter(),
            new EnumJsonConverterFactory(JsonNamingPolicy.CamelCase, true),
            new SortExpressionJsonConverter()
        },
        ReferenceHandler = ReferenceHandler.Preserve,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    private readonly IFixture fixture = new Fixture();
    private MockHttpMessageHandler mockHttpMessageHandler;

    [SetUp]
    public void SetUp()
    {
        this.mockHttpMessageHandler = new MockHttpMessageHandler();

        this.fixture.Customize<DemoRequest>(x => x
            .With(_ => _.Key, $"{Guid.NewGuid():N}")
            .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
            .OmitAutoProperties());

        this.fixture.Customize<DemoPostRequest>(x => x
            .With(_ => _.Key, $"{Guid.NewGuid():N}")
            .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
            .OmitAutoProperties());

        this.fixture.Customize<DemoStreamRequest>(x => x
            .With(_ => _.Key, $"{Guid.NewGuid():N}")
            .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
            .OmitAutoProperties());
    }

    [Test]
    public void QueryWhenOkTest()
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

        var result = httpEngine
            .Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
    public void QueryWhenOverLimit()
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));
        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(exception.Status, Status.OverQueryLimit);
    }

    [Test]
    public void QueryWhenInvalidRequest()
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));
        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(exception.Status, Status.InvalidRequest);
    }

    [Test]
    public void QueryWhenNoApiKey()
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(exception.Status, Status.InvalidKey);
    }

    [Test]
    public void QueryWhenRequestDenied()
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.AreEqual(Status.RequestDenied, exception.Status);
    }

    [Test]
    public void QueryWhenHttpError()
    {
        var data = new
        {
            status = "HTTP_ERROR",
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(Status.HttpError, exception.Status);
    }

    [Test]
    public void QueryWhenUnknownError()
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await httpEngine.QueryAsync(request, new HttpEngineOptions { ThrowOnInvalidRequest = true }));

        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception.Status);
        Assert.AreEqual(Status.UnknownError, exception.Status);
    }

    #region Query Based
    private sealed class DemoHttpEngine : HttpEngine<DemoRequest, DemoResponse>
    {
        public DemoHttpEngine(HttpClient client) : base(client)
        {
        }
    }

    private sealed class DemoRequest : BaseRequest, IRequestQueryString
    {
        protected override string BaseUrl => "demo.googleapis.com/fakeservice/";
    }

    private sealed class DemoResponse : BaseResponse
    {

    }
    #endregion

    #region Post Based
    private sealed class DemoPostHttpEngine : HttpEngine<DemoPostRequest, DemoPostResponse>
    {
        public DemoPostHttpEngine(HttpClient client) : base(client)
        {
        }
    }


    private sealed class DemoPostRequest : BaseRequest
    {
        protected override string BaseUrl => "demo.googleapis.com/fakeservice/";
    }

    private sealed class DemoPostResponse : BaseResponse
    {

    }
    #endregion

    #region Stream Based
    private sealed class DemoStreamHttpEngine : HttpEngine<DemoStreamRequest, DemoStreamResponse>
    {
        public DemoStreamHttpEngine(HttpClient client) : base(client)
        {
        }
    }

    private sealed class DemoStreamRequest : BaseRequest, IRequestQueryString
    {
        protected override string BaseUrl => "demo.googleapis.com/fakeservice/";
    }

    private sealed class DemoStreamResponse : BaseResponseStream
    {

    }
    #endregion
}