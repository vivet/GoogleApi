using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Places.Search.Common
{
    /// <summary>
    /// BasePlace Result.
    /// </summary>
    public abstract class BaseResult
    {        
        /// <summary>
        /// Icon contains the URL of a recommended icon which may be displayed to the user when indicating this result.
        /// </summary>
        [JsonProperty("icon")]
        public virtual string IconUrl { get; set; }

        /// <summary>
        /// Geometry contains geometry information about the result, generally including the location (geocode) of the place and (optionally) 
        /// the viewport identifying its general area of coverage.
        /// </summary>
        [JsonProperty("geometry")]
        public virtual Geometry Geometry { get; set; }

        /// <summary>
        /// Name contains the human-readable name for the returned result. 
        /// For establishment results, this is usually the business name.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// OpeningHours may contain the following information:
        /// </summary>
        [JsonProperty("opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// Photos — an array of photo objects, each containing a reference to an image. 
        /// A Place Search will return at most one photo object. Performing a Place Details request on the place may return up to ten photos. 
        /// More information about Place Photos and how you can use the images in your application can be found in the Place Photos documentation. 
        /// </summary>
        [JsonProperty("photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }

        /// <summary>
        /// PlaceId — a textual identifier that uniquely identifies a place. 
        /// To retrieve information about the place, pass this identifier in the placeId field of a Places API request. For more information about place IDs, see the place ID overview.
        /// </summary>
        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Scope — Indicates the scope of the placeId.
        /// Note: The scope field is included only in Nearby Search results and Place Details results. 
        /// You can only retrieve app-scoped places via the Nearby Search and the Place Details requests. 
        /// If the scope field is not present in a response, it is safe to assume the scope is GOOGLE
        /// </summary>
        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Scope? Scope { get; set; } = Places.Common.Enums.Scope.Google;

        /// <summary>
        /// AlternativePlaceIds — An array of zero, one or more alternative place IDs for the place, with a scope related to each alternative ID. 
        /// Note: This array may be empty or not present. 
        /// </summary>
        [JsonProperty("alt_ids")]
        public virtual IEnumerable<AlternativePlace> AlternativePlaceIds { get; set; }

        /// <summary>
        /// price_level — The price level of the place, on a scale of 0 to 4. 
        /// The exact amount indicated by a specific value will vary from region to region. 
        /// </summary>
        [JsonProperty("price_level")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PriceLevel? PriceLevel { get; set; }

        /// <summary>
        /// Rating contains the place's rating, from 1.0 to 5.0, based on aggregated user reviews.
        /// </summary>
        [JsonProperty("rating")]
        public virtual double Rating { get; set; }

        /// <summary>
        /// Types contains an array of feature types describing the given result. See the list of supported types for more information. 
        /// XML responses include multiple type elements if more than one type is assigned to the result.
        /// </summary>
        [JsonProperty("types", ItemConverterType = typeof(StringEnumOrDefaultConverter<PlaceLocationType>))]
        public virtual IEnumerable<PlaceLocationType?> Types { get; set; }

        /// <summary>
        /// permanently_closed is a boolean flag indicating whether the place has permanently shut down(value true). 
        /// If the place is not permanently closed, the flag is absent from the response.
        /// </summary>
        [JsonProperty("permanently_closed")]
        public virtual bool PermanentlyClosed { get; set; }
    }
}