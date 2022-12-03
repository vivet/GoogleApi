using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Response;

namespace GoogleApi.Interfaces.Places;

/// <inheritdoc />
public interface IAutoCompleteApi : IApi<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>
{

}