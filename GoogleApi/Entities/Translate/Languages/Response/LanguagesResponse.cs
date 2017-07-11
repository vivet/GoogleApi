using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Translate.Languages.Response
{
    /// <summary>
    /// Languages Response.
    /// </summary>
    [DataContract]
    public class LanguagesResponse : BaseResponse
    {
        /// <summary>
        /// Container for the languages results.
        /// </summary>
        [DataMember(Name = "data")]
        public virtual Data Data { get; set; }
    }
}