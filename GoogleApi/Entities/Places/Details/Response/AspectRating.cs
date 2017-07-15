using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Details.Response
{
    /// <summary>
    /// Aspect Rating.
    /// </summary>
    [DataContract(Name = "aspectRating")]
    public class AspectRating
    {
        /// <summary>
        /// Type the name of the aspect that is being rated. 
        /// E.g. atmosphere, service, food, overall, etc.
        /// </summary>
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        /// <summary>
        /// Rating the user's rating for this particular aspect, from 0 to 3.
        /// </summary>
        [JsonProperty("rating")]
        public virtual double Rating { get; set; }
    }
}