using Newtonsoft.Json;

namespace GoogleApi.Entities.Translate.Languages.Response
{
    /// <summary>
    /// Languages Response.
    /// </summary>
    public class LanguagesResponse : BaseResponse
    {
        /// <summary>
        /// Container for the languages results.
        /// </summary>
        [JsonProperty("data")]
        public virtual Data Data { get; set; }
    }
}