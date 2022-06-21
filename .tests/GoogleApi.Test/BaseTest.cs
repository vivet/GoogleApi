using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace GoogleApi.Test;

[TestFixture]
public abstract class BaseTest
{
    protected virtual AppSettings Settings { get; private set; }

    [OneTimeSetUp]
    public virtual void Setup()
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("application.default.json", optional: false)
            .AddJsonFile("application.json", optional: true)
            .AddUserSecrets<BaseTest>();

        var configuration = configurationBuilder
            .Build();

        this.Settings = configuration.Get<AppSettings>();
    }
}