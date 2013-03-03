using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    [DataContract(Name = "data")]
    public class Data
    {
        /// <summary>
        /// The translations returned by the queries. Same order.
        /// </summary>
        [DataMember(Name = "translations")]
        public IEnumerable<Translation> Translations { get; set; }
    }

    [DataContract]
    public class TranslateResponse : IResponseFor
    {        
        /// <summary>
        /// Data container returned by google translate.
        /// </summary>
        [DataMember(Name = "data")]
        public Data Data { get; set; }
    }
}
 
 

