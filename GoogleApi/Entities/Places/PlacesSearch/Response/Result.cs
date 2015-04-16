using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common.Response;

namespace GoogleApi.Entities.Places.PlacesSearch.Response
{
    [DataContract]
    public class Result
    {
        /// <summary>
        /// Geometry contains a location.
        /// </summary>
        [DataMember(Name = "geometry")]
        public virtual Geometry Geometry { get; set; }

        /// <summary>
        /// Icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map
        /// </summary>
        [DataMember(Name = "icon")]
        public virtual string Icon { get; set; }

        /// <summary>
        /// Id contains a unique stable identifier denoting this place. This identifier may not be used to retrieve information about this place, but can be used to consolidate data about this Place, and to verify the identity of a Place across separate searches. As ids can occasionally change, it's recommended that the stored id for a Place be compared with the id returned in later Details requests for the same Place, and updated if necessary.
        /// </summary>
        [DataMember(Name = "id")]
        public virtual string Id { get; set; }

        /// <summary>
        /// Name contains the human-readable name for the returned result. For establishment results, this is usually the canonicalized business name.
        /// </summary>
        [DataMember(Name = "name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Place Id
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Reference contains a token that can be used to query the Details service in future. This token may differ from the reference used in the request to the Details service. It is recommended that stored references for Places be regularly updated. Although this token uniquely identifies the Place, the converse is not true: a Place may have many valid reference tokens.
        /// </summary>
        [DataMember(Name = "reference")]
        public virtual string Reference { get; set; }

        /// <summary>
        /// Scope of place
        /// </summary>
        [DataMember(Name = "scope")]
        public virtual string Scope { get; set; }

        /// <summary>
        /// types[] contains an array of feature types describing the given result. See the list of supported types for more information. XML responses include multiple type elements if more than one type is assigned to the result.
        /// </summary>
        [DataMember(Name = "types")]
        public IEnumerable<string> Types { get; set; }

        /// <summary>
        /// Vicinity lists a simplified address for the Place, including the street name, street number, and locality, but not the province/state, postal code, or country. For example, Google's Sydney, Australia office has a vicinity value of 48 Pirrama Road, Pyrmont.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public virtual string Vicinity { get; set; }
    }
}
