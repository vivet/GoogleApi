using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Response status.
/// </summary>
public enum Status
{
    /// <summary>
    /// Indicates that no errors occurred; the place was successfully detected and at least one result was returned.
    /// </summary>
    [EnumMember(Value = "OK")]
    Ok,

    /// <summary>
    /// Indicates that the request was successful but returned no results.
    /// This may occur if the search was passed a latlng in a remote location.
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
    /// Indicates that too many waypointss were provided in the request The maximum allowed waypoints is 8, plus the origin, and destination.
    /// ( Google Maps Premier customers may contain requests with up to 23 waypoints.)
    /// </summary>
    [EnumMember(Value = "MAX_WAYPOINTS_EXCEEDED")]
    MaxWaypointsExceeded,

    /// <summary>
    /// Indicates the requested route is too long and cannot be processed. This error occurs when more complex directions are returned. Try reducing the number of waypoints, turns, or instructions.
    /// </summary>
    [EnumMember(Value = "MAX_ROUTE_LENGTH_EXCEEDED")]
    MaxRouteLengthExceeded,

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
    /// Indicates the request has none or an invalid key set.
    /// </summary>
    [EnumMember(Value = "NO_API_KEY")]
    InvalidKey,

    /// <summary>
    /// Indicates any of the following:
    /// The API key is missing or invalid.
    /// Billing has not been enabled on your account.
    /// A self-imposed usage cap has been exceeded.
    /// The provided method of payment is no longer valid (for example, a credit card has expired).
    /// </summary>
    [EnumMember(Value = "OVER_DAILY_LIMIT")]
    OverDailyLimit,

    /// <summary>
    /// Indicates that the number of origins or destinations exceeds the per-query limit.
    /// </summary>
    [EnumMember(Value = "MAX_DIMENSIONS_EXCEEDED")]
    MaxDimensionsExceeded,

    /// <summary>
    /// Invalid Argument.
    /// </summary>
    [EnumMember(Value = "INVALID_ARGUMENT")]
    InvalidArgument,

    /// <summary>
    /// Permission Denied.
    /// </summary>
    [EnumMember(Value = "PERMISSION_DENIED")]
    PermissionDenied,

    /// <summary>
    /// Resource Exhausted.
    /// </summary>
    [EnumMember(Value = "RESOURCE_EXHAUSTED")]
    ResourceExhausted,

    /// <summary>
    /// Data Not Available.
    /// </summary>
    [EnumMember(Value = "DATA_NOT_AVAILABE")]
    DataNotAvailable,

    /// <summary>
    /// Matrix Element Errors.
    /// </summary>
    MatrixElementErrors
}