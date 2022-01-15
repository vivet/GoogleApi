
using GoogleApi.Exceptions;
using RichardSzalay.MockHttp;
using System;
#if NETCOREAPP3_1_OR_GREATER
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace GoogleApi.UnitTests
{
    public abstract class HttpClientTest
    {
        protected const string ApplicationJson = "application/json";

        protected FakeWithTraceLogRequestHandler _FakeHandler;

        protected MockHttpMessageHandler Actor => _FakeHandler.InnerHandler as MockHttpMessageHandler;

        protected void ShowResult(GoogleApiException result)
        {
            Console.WriteLine(new { result.Status, result.Message }.ToJson());
        }

        protected void ShowResult(object result)
        {
            Console.WriteLine(result.ToJson());
        }

        protected IFixture _fixture = new Fixture();

    }
}