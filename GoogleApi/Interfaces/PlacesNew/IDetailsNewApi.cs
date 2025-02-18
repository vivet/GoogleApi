using GoogleApi.Entities.PlacesNew.Details.Request;
using GoogleApi.Entities.PlacesNew.Details.Response;

namespace GoogleApi.Interfaces.PlacesNew;

/// <inheritdoc />
public interface IDetailsNewApi : IApi<PlacesNewDetailsRequest, PlacesNewDetailsResponse>;