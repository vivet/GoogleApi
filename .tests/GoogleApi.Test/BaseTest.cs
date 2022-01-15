using AutoFixture;
using AutoFixture.AutoNSubstitute;
using GoogleApi.UnitTests;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Net.Http;

namespace GoogleApi.Test
{
    [TestFixture]
    public abstract class BaseTest<T> : BaseTest
    {
        /// <summary>
        ///  System Under Test
        /// </summary>
        protected T Sut { get; set; }

        [OneTimeSetUp]
        public void BeforeAll()
        {
            if (Settings.UseGlobalStaticHttpClients)
                Sut = GetClientStatic();
            else
                Sut = GetClient();
        }

        protected abstract T GetClientStatic();
        protected abstract T GetClient();
    }


    [TestFixture]
    public abstract class BaseTest
    {
        protected static AppSettings Settings;

        protected string ApiKey => Settings.ApiKey;
        protected string CryptoKey => Settings.CryptoKey;
        protected string ClientId => Settings.ClientId;
        protected string SearchEngineId => Settings.SearchEngineId;

        protected IFixture _fixture;
        protected static HttpClient _httpClient;

        [OneTimeSetUp]
        public virtual void Setup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("application.default.json", optional: true)
                .AddJsonFile("application.json", optional: true)
                .AddUserSecrets<BaseTest>();
            var config = builder.Build();

            Settings = config.Get<AppSettings>();

            var handler = new TraceLogRequestHandler();

            _httpClient = handler.ToHttpClient();
        }

        [SetUp]
        public void Init()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true });
            _fixture.Customize(new ApiKeyInterneSpecimenBuilder().ToCustomization());

            _fixture.Inject(Settings);
        }

        public class AppSettings
        {
            public string ApiKey { get; set; }

            public string CryptoKey { get; set; }

            public string ClientId { get; set; }

            public string SearchEngineId { get; set; }

            public bool UseGlobalStaticHttpClients { get; set; } = true;
        }
    }
}