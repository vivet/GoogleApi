using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Common.Enums
{
	[DataContract]
	public enum Status
	{
		[EnumMember(Value = "OK")]
		OK, // indicates that no errors occurred; the place was successfully detected and at least one result was returned.
		[EnumMember(Value = "ZERO_RESULTS")]
		ZERO_RESULTS, // indicates that the search was successful but returned no results. This may occur if the search was passed a latlng in a remote location.
		[EnumMember(Value = "OVER_QUERY_LIMIT")]
		OVER_QUERY_LIMIT, // indicates that you are over your quota.
		[EnumMember(Value = "REQUEST_DENIED")]
		REQUEST_DENIED, // indicates that your request was denied, generally because of lack of a sensor parameter.
		[EnumMember(Value = "INVALID_REQUEST")]
		INVALID_REQUEST, // generally indicates that the query parameter (location or radius) is missing.
		[EnumMember(Value = "MAX_ELEMENTS_EXCEEDED")]
		MAX_ELEMENTS_EXCEEDED, // indicates the allowed amount of elements has been exceeeded.
		[EnumMember]
		MAX_WAYPOINTS_EXCEEDED, // indicates that too many waypointss were provided in the request The maximum allowed waypoints is 8, plus the origin, and destination. ( Google Maps Premier customers may contain requests with up to 23 waypoints.)
		[EnumMember]
		NOT_FOUND, // indicates at least one of the locations specified in the requests's origin, destination, or waypoints could not be geocoded.
		[EnumMember]
		UNKNOWN_ERROR, // indicates a directions request could not be processed due to a server error. The request may succeed if you try again
    }
}
