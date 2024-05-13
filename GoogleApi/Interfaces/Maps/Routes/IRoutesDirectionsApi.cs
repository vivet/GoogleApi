using GoogleApi.Entities.Maps.Routes.Directions.Request;
using GoogleApi.Entities.Maps.Routes.Directions.Response;

namespace GoogleApi.Interfaces.Maps.Routes;

/// <inheritdoc />
public interface IRoutesDirectionsApi : IApi<RoutesDirectionsRequest, RoutesDirectionsResponse>;