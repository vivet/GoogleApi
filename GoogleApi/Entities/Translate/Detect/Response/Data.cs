using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Translate.Detect.Response
{
    /// <summary>
    /// The list of detection responses.
    /// This list will contain a language detection response for each query (q) sent in the language detection request.
    /// </summary>
    [DataContract(Name = "Data")]
    public class Data
    {
        /// <summary>
        /// A response list contains a list of separate language detection responses.
        /// Language detection results for each input text piece. For backward compatibility, this list must be expressed as an array of arrays, 
        /// which requires using ListValue in proto3.
        /// </summary>
        [JsonProperty("detections")]
        public virtual IEnumerable<Detection[]> Detections { get; set; }
    }
}