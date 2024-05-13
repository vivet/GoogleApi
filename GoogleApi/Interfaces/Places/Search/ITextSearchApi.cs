using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;

namespace GoogleApi.Interfaces.Places.Search;

/// <inheritdoc />
public interface ITextSearchApi : IApi<PlacesTextSearchRequest, PlacesTextSearchResponse>;