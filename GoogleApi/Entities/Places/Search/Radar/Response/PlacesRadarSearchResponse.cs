using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Search.Common;

namespace GoogleApi.Entities.Places.Search.Radar.Response
{
    /// <summary>
    /// Places RadarSearch Response
    /// </summary>
    [DataContract]
    public class PlacesRadarSearchResponse : BasePlacesSearchResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "results")]
        public virtual IEnumerable<RadarResult> Results { get; set; }
    }
}