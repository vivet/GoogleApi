using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    /// <summary>
    /// SnapToRoads Response.
    /// </summary>
    [DataContract]
    public class SnappedPoint
    {
        /// <summary>
        /// Location — Contains a latitude and longitude value.
        /// </summary>
        [DataMember(Name = "location")]
        public virtual Location Location { get; set; }

        /// <summary>
        /// OriginalIndex — An integer that indicates the corresponding value in the original request. 
        /// Each value in the request should map to a snapped value in the response. However, if you've set interpolate=true, then it's possible that the response will contain more coordinates than the request. 
        /// Interpolated values will not have an originalIndex. 
        /// These values are indexed from 0, so a point with an originalIndex of 4 will be the snapped value of the 5th latitude/longitude passed to the path parameter.
        /// </summary>
        [DataMember(Name = "originalIndex")]
        public virtual int? OriginalIndex { get; set; }

        /// <summary>
        /// PlaceId — A unique identifier for a place. All place IDs returned by the Google Maps Roads API correspond to road segments. Place IDs can be used with other Google APIs, including the Google Places API and the Google Maps JavaScript API. For example, if you need to get road names for the snapped points returned by the Google Maps Roads API, you can pass the placeId to the Google Places API or the Google Maps Geocoding API. Within the Google Maps Roads API, you can pass the placeId to the speedLimit method to determine the speed limit along that road segment.
        /// </summary>
        [DataMember(Name = "PlaceId")]
        public virtual string PlaceId { get; set; }
    }
}