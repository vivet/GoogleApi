using GoogleApi.Entities.PlacesNew.Search.Text.Request;
using GoogleApi.Entities.PlacesNew.Search.Text.Response;

namespace GoogleApi.Interfaces.PlacesNew.Search;

/// <inheritdoc />
public interface ITextSearchNewApi : IApi<PlacesNewTextSearchRequest, PlacesNewTextSearchResponse>;