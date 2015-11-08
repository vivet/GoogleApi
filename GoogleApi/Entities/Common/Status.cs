using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Respone status
    /// </summary>
	[DataContract]
	public enum Status
	{
        /// <summary>
        /// Indicates that no errors occurred; the place was successfully detected and at least one result was returned.
        /// </summary>
        [EnumMember(Value = "OK")]
		OK,
        /// <summary>
        /// Indicates that the search was successful but returned no results. This may occur if the search was passed a latlng in a remote location.
        /// </summary>
        [EnumMember(Value = "ZERO_RESULTS")]
		ZERO_RESULTS,
        /// <summary>
        /// Indicates that you are over your quota.
        /// </summary>
        [EnumMember(Value = "OVER_QUERY_LIMIT")]
		OVER_QUERY_LIMIT,
        /// <summary>
        /// Indicates that your request was denied, generally because of lack of a sensor parameter.
        /// </summary>
        [EnumMember(Value = "REQUEST_DENIED")]
		REQUEST_DENIED,
        /// <summary>
        /// Indicates that the query parameter (location or radius) is missing.
        /// </summary>
        [EnumMember(Value = "INVALID_REQUEST")]
		INVALID_REQUEST,
        /// <summary>
        /// Indicates the allowed amount of elements has been exceeeded.
        /// </summary>
        [EnumMember(Value = "MAX_ELEMENTS_EXCEEDED")]
		MAX_ELEMENTS_EXCEEDED,
        /// <summary>
        /// Indicates that too many waypointss were provided in the request The maximum allowed waypoints is 8, plus the origin, and destination. ( Google Maps Premier customers may contain requests with up to 23 waypoints.)	
        /// </summary>
        [EnumMember(Value = "MAX_WAYPOINTS_EXCEEDED")]
        MAX_WAYPOINTS_EXCEEDED,
        /// <summary>
        /// Indicates at least one of the locations specified in the requests's origin, destination, or waypoints could not be geocoded.
        /// </summary>
        [EnumMember(Value = "NOT_FOUND")]
        NOT_FOUND,
        /// <summary>
        /// Indicates a directions request could not be processed due to a server error. The request may succeed if you try again
        /// </summary>
        [EnumMember(Value = "UNKNOWN_ERROR")]
        UNKNOWN_ERROR, 
    }
}
