using GoogleApi.Entities.PlacesNew.Search.NearBy.Request;
using GoogleApi.Entities.PlacesNew.Search.NearBy.Response;

namespace GoogleApi.Interfaces.PlacesNew.Search;

/// <inheritdoc />
public interface INearBySearchNewApi : IApi<PlacesNewNearBySearchRequest, PlacesNewNearbySearchResponse>;