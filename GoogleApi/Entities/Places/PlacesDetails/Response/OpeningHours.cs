using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class OpeningHours
    {
        /// <summary>
        /// OpenNow is a boolean value indicating if the Place is open at the current time.
        /// </summary>
        [DataMember(Name = "open_now")]
        public virtual bool OpenNow { get; set; }

        /// <summary>
        /// periods[] is an array of opening periods covering seven days, starting from Sunday, in chronological order.
        /// </summary>
        [DataMember(Name = "periods")]
        public virtual IEnumerable<Period> Periods { get; set; }
    }
}