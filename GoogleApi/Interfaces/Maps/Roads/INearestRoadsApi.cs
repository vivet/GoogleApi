using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Response;

namespace GoogleApi.Interfaces.Maps.Roads;

/// <inheritdoc />
public interface INearestRoadsApi : IApi<NearestRoadsRequest, NearestRoadsResponse>;