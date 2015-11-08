using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.Search.Common
{
    /// <summary>
    /// BasePlace Result.
    /// </summary>
    [DataContract]
    public abstract class BaseResult
    {
        /// <summary>
        /// PlaceId — a textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeId field of a Places API request. For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Geometry contains geometry information about the result, generally including the location (geocode) of the place and (optionally) the viewport identifying its general area of coverage.
        /// </summary>
        [DataMember(Name = "geometry")]
        public virtual Geometry Geometry { get; set; }

    }
}