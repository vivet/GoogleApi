using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Translate.Response
{
    /// <summary>
    /// Data.
    /// </summary>
    [DataContract(Name = "data")]
    public class Data
    {
        /// <summary>
        /// The translations returned by the queries. Same order.
        /// </summary>
        [DataMember(Name = "translations")]
        public virtual IEnumerable<Translation> Translations { get; set; }
    }
}