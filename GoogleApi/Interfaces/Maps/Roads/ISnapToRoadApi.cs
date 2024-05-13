using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Response;

namespace GoogleApi.Interfaces.Maps.Roads;

/// <inheritdoc />
public interface ISnapToRoadApi : IApi<SnapToRoadsRequest, SnapToRoadsResponse>;