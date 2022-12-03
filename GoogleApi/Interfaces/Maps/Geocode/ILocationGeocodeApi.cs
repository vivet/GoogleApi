using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;

namespace GoogleApi.Interfaces.Maps.Geocode;

/// <inheritdoc />
public interface ILocationGeocodeApi : IApi<LocationGeocodeRequest, GeocodeResponse>
{

}