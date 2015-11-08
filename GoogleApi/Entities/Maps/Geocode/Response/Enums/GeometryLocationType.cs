using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geocode.Response.Enums
{
    /// <summary>
    /// LocationType
    /// </summary>
	[DataContract]
	public enum GeometryLocationType
	{
        /// <summary>
        /// Indicates that the returned result is a precise geocode for which we have location information accurate down to street address precision.
        /// </summary>
        [EnumMember(Value = "ROOFTOP")]
        ROOFTOP, 
        /// <summary>
        /// Indicates that the returned result reflects an approximation (usually on a road) interpolated between two precise points (such as intersections). Interpolated results are generally returned when rooftop geocodes are unavailable for a street address.
        /// </summary>
        [EnumMember(Value = "RANGE_INTERPOLATED")]
        RANGE_INTERPOLATED,
        /// <summary>
        /// Indicates that the returned result is the geometric center of a result such as a polyline (for example, a street) or polygon (region).
        /// </summary>
        [EnumMember(Value = "GEOMETRIC_CENTER")]
        GEOMETRIC_CENTER, 
        /// <summary>
        /// Indicates that the returned result is approximate.
        /// </summary>
        [EnumMember(Value = "APPROXIMATE")]
        APPROXIMATE 
	}
}
