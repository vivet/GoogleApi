using GoogleApi.Entities.PlacesNew.AutoComplete.Request;
using GoogleApi.Entities.PlacesNew.AutoComplete.Response;

namespace GoogleApi.Interfaces.PlacesNew;

/// <inheritdoc />
public interface IAutoCompleteNewApi : IApi<PlacesNewAutoCompleteRequest, PlacesNewAutoCompleteResponse>;