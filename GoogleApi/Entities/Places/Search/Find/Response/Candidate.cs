using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Places.Search.Find.Response
{
    /// <summary>
    /// Candidate.
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// Name contains the human-readable name for the returned result.
        /// For establishment results, this is usually the canonicalized business name.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map
        /// </summary>
        [JsonProperty("icon")]
        public virtual string Icon { get; set; }

        /// <summary>
        /// A textual identifier that uniquely identifies a place.
        /// </summary>
        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// FormattedAddress is a string containing the human-readable address of this place. 
        /// Often this address is equivalent to the "postal address". 
        /// The formatted_address property is only returned for a Text Search.
        /// </summary>
        [JsonProperty("formatted_address")]
        public virtual string FormatttedAddress { get; set; }

        /// <summary>
        /// Geometry contains a location.
        /// </summary>
        [JsonProperty("geometry")]
        public virtual Geometry Geometry { get; set; }

        /// <summary>
        /// opening_hours may contain information about the place opening hours.
        /// </summary>
        [JsonProperty("opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// Scope — Indicates the scope of the placeId.
        /// Note: The scope field is included only in Nearby Search results and Place Details results. 
        /// You can only retrieve app-scoped places via the Nearby Search and the Place Details requests. 
        /// If the scope field is not present in a response, it is safe to assume the scope is GOOGLE
        /// </summary>
        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Scope Scope { get; set; }

        /// <summary>
        /// Rating the user's overall rating for this place. This is a whole number, ranging from 1 to 5.
        /// </summary>
        [JsonProperty("rating")]
        public virtual double Rating { get; set; }

        /// <summary>
        /// Photos.
        /// An array of photo objects, each containing a reference to an image. A Place Details request may return up to ten photos.
        /// </summary>
        [JsonProperty("photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }
    }
}