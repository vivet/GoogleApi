using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Elevation.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface IElevationApi : IApi<ElevationRequest, ElevationResponse>;