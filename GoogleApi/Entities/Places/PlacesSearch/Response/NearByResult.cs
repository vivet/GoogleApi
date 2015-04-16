using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.PlacesSearch.Response
{
    [DataContract]
    public class NearByResult : RadarResult
    {
        /// <summary>
        /// Icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map
        /// </summary>
        [DataMember(Name = "icon")]
        public virtual string Icon { get; set; }
        
        /// <summary>
        /// Name contains the human-readable name for the returned result. For establishment results, this is usually the canonicalized business name.
        /// </summary>
        [DataMember(Name = "name")]
        public virtual string Name { get; set; }
        
        /// <summary>
        /// Scope of place
        /// </summary>
        [DataMember(Name = "scope")]
        public virtual string Scope { get; set; }

        /// <summary>
        /// types[] contains an array of feature types describing the given result. See the list of supported types for more information. XML responses include multiple type elements if more than one type is assigned to the result.
        /// </summary>
        public IEnumerable<PlaceType> Types { get; set; }

        [DataMember(Name = "types")]
        internal virtual IEnumerable<string> TypesStr
        {
            get { return Types.Select(EnumHelper.ToEnumString); }
            set { Types = value.Select(EnumHelper.ToEnum<PlaceType>); }
        }

        /// <summary>
        /// Vicinity lists a simplified address for the Place, including the street name, street number, and locality, but not the province/state, postal code, or country. For example, Google's Sydney, Australia office has a vicinity value of 48 Pirrama Road, Pyrmont.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public virtual string Vicinity { get; set; }
    }
}
