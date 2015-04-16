using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Common.Enums
{
	[DataContract]
	public enum Status
	{
		[EnumMember(Value = "OK")]
		Ok, // indicates that no errors occurred; the place was successfully detected and at least one result was returned.
		[EnumMember(Value = "ZERO_RESULTS")]
		ZeroResults, // indicates that the search was successful but returned no results. This may occur if the search was passed a latlng in a remote location.
		[EnumMember(Value = "OVER_QUERY_LIMIT")]
		OverQueryLimit, // indicates that you are over your quota.
		[EnumMember(Value = "REQUEST_DENIED")]
		RequestDenied, // indicates that your request was denied, generally because of lack of a sensor parameter.
		[EnumMember(Value = "INVALID_REQUEST")]
		InvalidRequest, // generally indicates that the query parameter (location or radius) is missing.
        [EnumMember(Value = "MAX_WAYPOINTS_EXCEEDED")]
		MaxWaypointsExceeded, // indicates that too many waypointss were provided in the request The maximum allowed waypoints is 8, plus the origin, and destination. ( Google Maps Premier customers may contain requests with up to 23 waypoints.)
        [EnumMember(Value = "NOT_FOUND")]
		NotFound, // indicates at least one of the locations specified in the requests's origin, destination, or waypoints could not be geocoded.
        [EnumMember(Value = "UNKNOWN_ERROR")]
		UnknownError, // indicates a directions request could not be processed due to a server error. The request may succeed if you try again
    
    }
}
