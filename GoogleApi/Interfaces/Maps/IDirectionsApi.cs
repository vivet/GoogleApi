using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface IDirectionsApi : IApi<DirectionsRequest, DirectionsResponse>
{

}