using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Search.NearBy.Response
{
    /// <summary>
    /// NearBy Result.
    /// </summary>
    [DataContract]
    public class NearByResult : BaseResult
    {
        /// <summary>
        /// Icon contains the URL of a recommended icon which may be displayed to the user when indicating this result.
        /// </summary>
        [DataMember(Name = "icon")]
        public virtual string IconUrl { get; set; }
        
        /// <summary>
        /// Name contains the human-readable name for the returned result. For establishment results, this is usually the business name.
        /// </summary>
        [DataMember(Name = "name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// OpeningHours may contain the following information:
        /// </summary>
        [DataMember(Name = "opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// Photos — an array of photo objects, each containing a reference to an image. A Place Search will return at most one photo object. Performing a Place Details request on the place may return up to ten photos. More information about Place Photos and how you can use the images in your application can be found in the Place Photos documentation. A photo object is described as:
        /// </summary>
        [DataMember(Name = "photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }

        /// <summary>
        /// AlternativePlaceIds — An array of zero, one or more alternative place IDs for the place, with a scope related to each alternative ID. Note: This array may be empty or not present. 
        /// If present, it contains the following fields:
        /// </summary>
        [DataMember(Name = "alt_ids")]
        public virtual IEnumerable<AlternativePlace> AlternativePlaceIds { get; set; }

        /// <summary>
        /// Rating contains the place's rating, from 1.0 to 5.0, based on aggregated user reviews.
        /// </summary>
        [DataMember(Name = "rating")]
        public virtual double Rating { get; set; }

        /// <summary>
        /// Types contains an array of feature types describing the given result. See the list of supported types for more information. 
        /// XML responses include multiple type elements if more than one type is assigned to the result.
        /// </summary>
        public virtual IEnumerable<PlaceLocationType> Types { get; set; }

        [DataMember(Name = "types")]
        protected virtual IEnumerable<string> TypesStr
        {
            get { return this.Types.Select(EnumHelper.ToEnumString); }
            set
            {
                this.Types = value.Select(EnumHelper.ToEnum<PlaceLocationType>);
            }
        }

        /// <summary>
        /// Vicinity contains a feature name of a nearby location. Often this feature refers to a street or neighborhood within the given results. The vicinity property is only returned for a Nearby Search.
        /// </summary>
        [DataMember(Name = "vicinity")]
        public virtual string Vicinity { get; set; }

        /// <summary>
        /// Scope — Indicates the scope of the placeId.
        /// Note: The scope field is included only in Nearby Search results and Place Details results. You can only retrieve app-scoped places via the Nearby Search and the Place Details requests. 
        /// If the scope field is not present in a response, it is safe to assume the scope is GOOGLE
        /// </summary>
        public virtual Scope Scope { get; set; }

        [DataMember(Name = "scope")]
        protected virtual string ScopeStr
        {
            get { return EnumHelper.ToEnumString(this.Scope); }
            set { this.Scope = EnumHelper.ToEnum<Scope>(value); }
        }

        /// <summary>
        /// price_level — The price level of the place, on a scale of 0 to 4. The exact amount indicated by a specific value will vary from region to region. Price levels are interpreted as follows:
        /// </summary>
        public virtual PriceLevel PriceLevel { get; set; }

        [DataMember(Name = "price_level")]
        protected virtual string PriceLevelStr
        {
            get { return EnumHelper.ToEnumString(this.PriceLevel); }
            set { this.PriceLevel = EnumHelper.ToEnum<PriceLevel>(value); }
        }
    }
}
