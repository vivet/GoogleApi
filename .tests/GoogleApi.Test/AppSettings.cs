using Newtonsoft.Json;

namespace GoogleApi.Test;

public class AppSettings
{
    [JsonProperty("ApiKey")]
    public string ApiKey { get; set; }

    [JsonProperty("CryptoKey")]
    public string CryptoKey { get; set; }

    [JsonProperty("ClientId")]
    public string ClientId { get; set; }

    [JsonProperty("SearchEngineId")]
    public string SearchEngineId { get; set; }
}