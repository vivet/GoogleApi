using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums
{
    /// <summary>
    /// Response status.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Set when deserialization fails (default).
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Indicates that no errors occurred; the place was successfully detected and at least one result was returned.
        /// </summary>
        [EnumMember(Value = "OK")]
        Ok,

        /// <summary>
        /// Indicates that the request was successful but returned no results. This may occur if the search was passed a latlng in a remote location.
        /// </summary>
        [EnumMember(Value = "ZERO_RESULTS")]
        ZeroResults,

        /// <summary>
        /// Indicates that you are over your quota.
        /// </summary>
        [EnumMember(Value = "OVER_QUERY_LIMIT")]
        OverQueryLimit,

        /// <summary>
        /// Indicates that your request was denied.
        /// </summary>
        [EnumMember(Value = "REQUEST_DENIED")]
        RequestDenied,

        /// <summary>
        /// Indicates that the query parameter (location or radius) is missing.
        /// </summary>
        [EnumMember(Value = "INVALID_REQUEST")]
        InvalidRequest,

        /// <summary>
        /// Indicates the allowed amount of elements has been exceeeded.
        /// </summary>
        [EnumMember(Value = "MAX_ELEMENTS_EXCEEDED")]
        MaxElementsExceeded,

        /// <summary>
        /// Indicates that too many waypointss were provided in the request The maximum allowed waypoints is 8, plus the origin, and destination. ( Google Maps Premier customers may contain requests with up to 23 waypoints.)	
        /// </summary>
        [EnumMember(Value = "MAX_WAYPOINTS_EXCEEDED")]
        MaxWaypointsExceeded,

        /// <summary>
        /// Indicates at least one of the locations specified in the requests's origin, destination, or waypoints could not be geocoded.
        /// </summary>
        [EnumMember(Value = "NOT_FOUND")]
        NotFound,

        /// <summary>
        /// Indicates the request could not be processed due to a server error. The request may succeed if you try again.
        /// </summary>
        [EnumMember(Value = "UNKNOWN_ERROR")]
        UnknownError,

        /// <summary>
        /// Indicates the request resulted in a Http error code.
        /// </summary>
        [EnumMember(Value = "HTTP_ERROR")]
        HttpError,

        /// <summary>
        /// Indicates the request has none or an invalid key set.
        /// </summary>
        [EnumMember(Value = "NO_API_KEY")]
        InvalidKey
    }
}
