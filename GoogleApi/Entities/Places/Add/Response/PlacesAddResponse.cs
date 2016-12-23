using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;

namespace GoogleApi.Entities.Places.Add.Response
{
    /// <summary>
    /// Places Add Response.
    /// </summary>
    [DataContract]
    public class PlacesAddResponse : BasePlacesResponse
    {
        /// <summary>
        /// A unique stable identifier denoting this place. 
        /// This identifier cannot be used to retrieve information about this place, but is guaranteed to be valid across sessions. 
        /// It can be used to consolidate data about this place, and to verify the identity of a place across separate searches. 
        /// Note: The id is deprecated in favor of place_id. See the deprecation notice on this page.
        /// </summary>
        [DataMember(Name = "id")]
        public virtual string Id { get; set; }
        
        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeid field of a Place Details request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Indicates the scope of the place_id. 
        /// </summary>
        [DataMember(Name = "scope")]
        public virtual Scope Scope { get; set; }

        /// <summary>
        /// A unique token that you can use to retrieve additional information about this place. 
        /// Note: The reference is deprecated in favor of place_id. See the deprecation notice on this page.
        /// </summary>
        [DataMember(Name = "reference")]
        public virtual string Reference { get; set; }
    }
}