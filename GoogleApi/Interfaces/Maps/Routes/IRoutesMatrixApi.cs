using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using GoogleApi.Entities.Maps.Routes.Matrix.Response;

namespace GoogleApi.Interfaces.Maps.Routes;

/// <inheritdoc />
public interface IRoutesMatrixApi : IApi<RoutesMatrixRequest, RoutesMatrixResponse>;