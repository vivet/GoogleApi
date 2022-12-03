using GoogleApi.Entities.Maps.StreetView.Request;
using GoogleApi.Entities.Maps.StreetView.Response;

namespace GoogleApi.Interfaces.Maps;

/// <inheritdoc />
public interface IStreetViewApi : IApi<StreetViewRequest, StreetViewResponse>
{

}