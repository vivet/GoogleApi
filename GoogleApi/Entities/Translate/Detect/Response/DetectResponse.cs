using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Detect.Response
{
    /// <summary>
    /// Detect Response.
    /// </summary>
    [DataContract]
    public class DetectResponse : BaseResponse
    {
        /// <summary>
        /// Container for the detected results.
        /// </summary>
        [DataMember(Name = "data")]
        public virtual Data Data { get; set; }
    }
}