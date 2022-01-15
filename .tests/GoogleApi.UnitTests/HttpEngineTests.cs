#if NETCOREAPP3_1_OR_GREATER
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Microsoft.Extensions.DependencyInjection;
#else
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
#endif
using FluentAssertions;
using GoogleApi.Entities;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Exceptions;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleApi.UnitTests
{
    [TestFixture]
    public sealed class HttpEngineTests : HttpClientTest
    {

        [SetUp]
        public void Init()
        {
            _FakeHandler = new FakeWithTraceLogRequestHandler();

#if NETCOREAPP3_1_OR_GREATER

            _fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true });
            _fixture.Customize<DemoRequest>(x => x
                .With(_ => _.Key, () => $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, () => $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );

            _fixture.Customize<DemoPostRequest>(x => x
                .With(_ => _.Key, () => $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, () => $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );

            _fixture.Customize<DemoStreamRequest>(x => x
                .With(_ => _.Key, () => $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, () => $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );
#else
            _fixture.Customize<DemoRequest>(x => x
                .With(_ => _.Key, $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );

            _fixture.Customize<DemoPostRequest>(x => x
                .With(_ => _.Key, $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );

            _fixture.Customize<DemoStreamRequest>(x => x
                .With(_ => _.Key, $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );
#endif

        }

        [Test]
        public void WhenQuery_non_async_ThenOk()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "OK",
                    data = new { }
                }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = sut.Query(request);

            Assert.IsNotNull(result);

            ShowResult(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }


        [Test]
        public async Task WhenQueryThenOk()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "OK",
                    data = new { }
                }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = await sut.QueryAsync(request);

            Assert.IsNotNull(result);

            ShowResult(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public async Task WhenQuery_post_ThenOk()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "OK",
                    data = new { }
                }.ToJson());

            var request = _fixture.Create<DemoPostRequest>();

            var sut = new DemoPostHttpEngine(_FakeHandler.ToHttpClient());
            var result = await sut.QueryAsync(request);
            Assert.IsNotNull(result);

            ShowResult(result);
            result.Status.Should().Be(Status.Ok);
        }


        [Test]
        public async Task WhenQuery_Then_stream_Ok()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(r => new StreamContent(new MemoryStream()));

            var request = _fixture.Create<DemoStreamRequest>();

            var sut = new DemoStreamHttpEngine(_FakeHandler.ToHttpClient());
            var result = await sut.QueryAsync(request);
            Assert.IsNotNull(result);

            ShowResult(new { result.Status, result.ErrorMessage });
            result.Status.Should().Be(Status.Ok);
            result.Buffer.Should().NotBeNull();
        }

        [Test]
        public async Task WhenQueryThenNotFound()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "NOT_FOUND",
                    data = new { }
                }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = await sut.QueryAsync(request);

            Assert.IsNotNull(result);

            ShowResult(result);
            result.Status.Should().Be(Status.NotFound);
        }

        [Test]
        public async Task WhenQueryThenZeroResults()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "ZERO_RESULTS",
                    data = new { }
                }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = await sut.QueryAsync(request);

            Assert.IsNotNull(result);

            ShowResult(result);
            result.Status.Should().Be(Status.ZeroResults);
        }

        [Test]
        public void WhenQueryThenOverLimit()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "OVER_QUERY_LIMIT"
                }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = Assert.ThrowsAsync<GoogleApiException>(async () => await sut.QueryAsync(request, new HttpEngineOptions(true)));

            result.Should().NotBeNull();
            ShowResult(result);
        }

        [Test]
        public void WhenQueryThenInvalidRequest()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(ApplicationJson, new
                {
                    status = "INVALID_REQUEST"
                }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = Assert.ThrowsAsync<GoogleApiException>(async () => await sut.QueryAsync(request, new HttpEngineOptions(true)));

            result.Should().NotBeNull();
            ShowResult(result);
        }

        [Test]
        public void WhenQueryThenNoApiKey()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(
                    ApplicationJson,
                    new
                    {
                        status = "NO_API_KEY"
                    }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = Assert.ThrowsAsync<GoogleApiException>(async () => await sut.QueryAsync(request, new HttpEngineOptions(true)));

            result.Should().NotBeNull();
            ShowResult(result);
            result.Status.Should().Be(Status.InvalidKey);
        }

        [Test]
        public void WhenQueryThenRequestDenied()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(
                    ApplicationJson,
                    new
                    {
                        status = "REQUEST_DENIED"
                    }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = Assert.ThrowsAsync<GoogleApiException>(async () => await sut.QueryAsync(request, new HttpEngineOptions(true)));

            result.Should().NotBeNull();
            ShowResult(result);
            result.Status.Should().Be(Status.RequestDenied);
        }

        [Test]
        public void WhenQueryThenHttpError()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(
                    ApplicationJson,
                    new
                    {
                        status = "HTTP_ERROR"
                    }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = Assert.ThrowsAsync<GoogleApiException>(async () => await sut.QueryAsync(request, new HttpEngineOptions(true)));

            result.Should().NotBeNull();
            ShowResult(result);
            result.Status.Should().Be(Status.HttpError);
        }

        [Test]
        public void WhenQueryThenUnknownError()
        {
            Actor.When("https://demo.googleapis.com/fakeservice/*")
                .Respond(
                    ApplicationJson,
                    new
                    {
                        status = "UNKNOWN_ERROR"
                    }.ToJson());

            var request = _fixture.Create<DemoRequest>();

            var sut = new DemoHttpEngine(_FakeHandler.ToHttpClient());
            var result = Assert.ThrowsAsync<GoogleApiException>(async () => await sut.QueryAsync(request, new HttpEngineOptions(true)));

            result.Should().NotBeNull();
            ShowResult(result);
            result.Status.Should().Be(Status.UnknownError);
        }

        #region QueryBased
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

        #region PostBased
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

        #region StreamBased
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
}
