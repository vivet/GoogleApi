using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common.Enums;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Alternative Place.
    /// </summary>
    [DataContract]
    public class AlternativePlace
    {
        /// <summary>
        /// PlaceId — The most likely reason for a place to have an alternative place ID is if your application adds a place and receives an application-scoped place ID, 
        /// then later receives a Google-scoped place ID after passing the moderation process.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Scope — Indicates the scope of the Alternative PlaceId.
        /// The scope of an alternative place ID will always be APP, indicating that the alternative place ID is recognised by your application only.
        /// </summary>
        [DataMember(Name = "scope")]
        public virtual Scope Scope { get; set; }
    }
}