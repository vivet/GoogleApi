using System.Text.Json.Serialization;

namespace IntegrationTests.GoogleApi;

public class AppSettings
{
    [JsonPropertyName("ApiKey")]
    public string ApiKey { get; set; }

    [JsonPropertyName("SearchEngineId")]
    public string SearchEngineId { get; set; }
}