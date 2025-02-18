using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Geocode.
/// Contains information about the place the input was geocoded to.
/// </summary>
public class Geocode
{
    /// <summary>
    /// Location.
    /// The geocoded location of the input.
    /// Using place IDs is preferred over using addresses, latitude/longitude coordinates, or plus codes.
    /// Using coordinates when routing or calculating driving directions will always result in the point being snapped to the road nearest to those coordinates.
    /// This may not be a road that will quickly or safely lead to the destination and may not be near an access point to the property.
    /// Additionally, when a location is reverse geocoded, there is no guarantee that the returned address will match the original.
    /// </summary>
    public virtual LatLng Location { get; set; }

    /// <summary>
    /// Plus Code.
    /// The plus code corresponding to the location.
    /// </summary>
    public virtual PlusCode PlusCode { get; set; }

    /// <summary>
    /// Bounds.
    /// The bounds of the geocoded place.
    /// </summary>
    public virtual Viewport Bounds { get; set; }

    /// <summary>
    /// Feature Size Meters.
    /// The size of the geocoded place, in meters. This is another measure of the coarseness of the geocoded location, but in physical size rather than in semantic meaning.
    /// </summary>
    public virtual double? FeatureSizeMeters { get; set; }

    /// <summary>
    /// Place Id.
    /// The PlaceID of the place this input geocodes to.
    /// For more information about Place IDs see here: https://developers.google.com/maps/documentation/places/web-service/place-id
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// Place Types.
    /// The type(s) of place that the input geocoded to.
    /// For example, ['locality', 'political'].
    /// The full list of types can be found here: https://developers.google.com/maps/documentation/geocoding/requests-geocoding#Types
    /// </summary>
    public virtual IEnumerable<AddressComponentType> PlaceTypes { get; set; }
}