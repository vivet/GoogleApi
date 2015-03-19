using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    [DataContract]
    public class TranslateResponse : IResponseFor
    {        
        /// <summary>
        /// Data container returned by google translate.
        /// </summary>
        [DataMember(Name = "data")]
        public virtual Data Data { get; set; }
    }
}
 
 

