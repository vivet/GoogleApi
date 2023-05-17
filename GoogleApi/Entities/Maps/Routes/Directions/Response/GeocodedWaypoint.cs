using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Geocoded Waypoint.
/// Details about the locations used as waypoints.
/// Only populated for address waypoints.
/// Includes details about the geocoding results for the purposes of determining what the address was geocoded to.
/// </summary>
public class GeocodedWaypoint
{
    /// <summary>
    /// Geocoder Status.
    /// Indicates the status code resulting from the geocoding operation.
    /// </summary>
    public virtual GeocoderStatus GeocoderStatus { get; set; }

    /// <summary>
    /// Type.
    /// The type(s) of the result, in the form of zero or more type tags.
    /// Supported types: https://developers.google.com/maps/documentation/geocoding/requests-geocoding#Types
    /// </summary>
    public virtual IEnumerable<AddressComponentType> Type { get; set; }

    /// <summary>
    /// Partial Match.
    /// Indicates that the geocoder did not return an exact match for the original request,
    /// though it was able to match part of the requested address.
    /// You may wish to examine the original request for misspellings and/or an incomplete address.
    /// </summary>
    public virtual bool PartialMatch { get; set; }

    /// <summary>
    /// Place Id.
    /// The place ID for this result.
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// Intermediate Waypoint Request Index.
    /// The index of the corresponding intermediate waypoint in the request.
    /// Only populated if the corresponding waypoint is an intermediate waypoint.
    /// </summary>
    public virtual int IntermediateWaypointRequestIndex { get; set; }
}