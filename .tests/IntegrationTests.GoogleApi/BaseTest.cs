using Microsoft.Extensions.Configuration;

namespace GoogleApi.Test;

public abstract class BaseTest
{
    protected virtual AppSettings Settings { get; private set; }

    protected BaseTest()
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