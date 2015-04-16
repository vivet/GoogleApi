using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Places.PlacesSearch.Response
{
    [DataContract]
    public class PlacesRadarSearchResponse : MapsBaseResponse, IResponseFor
    {
        [DataMember(Name = "results")]
        public virtual IEnumerable<RadarResult> Results { get; set; }
    }
}