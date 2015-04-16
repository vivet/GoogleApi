using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common.Response;

namespace GoogleApi.Entities.Places.PlacesSearch.Response
{
    [DataContract]
    public class RadarResult
    {
        /// <summary>
        /// Geometry contains a location.
        /// </summary>
        [DataMember(Name = "geometry")]
        public virtual Geometry Geometry { get; set; }
        
        /// <summary>
        /// Id contains a unique stable identifier denoting this place. This identifier may not be used to retrieve information about this place, but can be used to consolidate data about this Place, and to verify the identity of a Place across separate searches. As ids can occasionally change, it's recommended that the stored id for a Place be compared with the id returned in later Details requests for the same Place, and updated if necessary.
        /// </summary>
        [DataMember(Name = "id")]
        [Obsolete("Deprecated as of 2014-06-24 https://developers.google.com/places/webservice/search")]
        public virtual string Id { get; set; }
        
        /// <summary>
        /// Place Id
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Reference contains a token that can be used to query the Details service in future. This token may differ from the reference used in the request to the Details service. It is recommended that stored references for Places be regularly updated. Although this token uniquely identifies the Place, the converse is not true: a Place may have many valid reference tokens.
        /// </summary>
        [DataMember(Name = "reference")]
        [Obsolete("Deprecated as of 2014-06-24 https://developers.google.com/places/webservice/search")]
        public virtual string Reference { get; set; }
    }
}