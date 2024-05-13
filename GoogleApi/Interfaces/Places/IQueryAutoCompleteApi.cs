using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;

namespace GoogleApi.Interfaces.Places;

/// <inheritdoc />
public interface IQueryAutoCompleteApi : IApi<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>;