using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;

namespace GoogleApi.Interfaces.Maps.Roads;

/// <inheritdoc />
public interface ISpeedLimitsApi : IApi<SpeedLimitsRequest, SpeedLimitsResponse>
{

}