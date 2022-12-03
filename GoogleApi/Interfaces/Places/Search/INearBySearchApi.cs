using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;

namespace GoogleApi.Interfaces.Places.Search;

/// <inheritdoc />
public interface INearBySearchApi : IApi<PlacesNearBySearchRequest, PlacesNearbySearchResponse>
{

}