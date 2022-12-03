using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geolocation.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface IGeolocationApi : IApi<GeolocationRequest, GeolocationResponse>
{

}