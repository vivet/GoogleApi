using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface IDistanceMatrixApi : IApi<DistanceMatrixRequest, DistanceMatrixResponse>;