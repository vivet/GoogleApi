using GoogleApi.Entities.Places.Search.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.NearBy.Response
{
    /// <summary>
    /// NearBy Result.
    /// </summary>
    public class NearByResult : BaseResult
    {
        /// <summary>
        /// Vicinity contains a feature name of a nearby location. 
        /// Often this feature refers to a street or neighborhood within the given results. 
        /// The vicinity property is only returned for a Nearby Search.
        /// </summary>
        [JsonProperty("vicinity")]
        public virtual string Vicinity { get; set; }
    }
}