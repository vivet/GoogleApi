using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;

namespace GoogleApi.Interfaces.Maps.Geocode;

/// <inheritdoc />
public interface IPlusCodeGeocodeApi : IApi<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>;