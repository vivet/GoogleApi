using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Response;

namespace GoogleApi.Interfaces.Places.Search;

/// <inheritdoc />
public interface IFindSearchApi : IApi<PlacesFindSearchRequest, PlacesFindSearchResponse>
{

}