using Newtonsoft.Json;

namespace GoogleApi.Test;

public class AppSettings
{
    [JsonProperty("ApiKey")]
    public string ApiKey { get; set; }

    [JsonProperty("SearchEngineId")]
    public string SearchEngineId { get; set; }
}