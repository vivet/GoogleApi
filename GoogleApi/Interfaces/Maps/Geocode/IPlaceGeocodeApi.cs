using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;

namespace GoogleApi.Interfaces.Maps.Geocode;

/// <inheritdoc />
public interface IPlaceGeocodeApi : IApi<PlaceGeocodeRequest, GeocodeResponse>;