using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Entities.Maps.TimeZone.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface ITimeZoneApi : IApi<TimeZoneRequest, TimeZoneResponse>;