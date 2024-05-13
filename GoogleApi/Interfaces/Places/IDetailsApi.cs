using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;

namespace GoogleApi.Interfaces.Places;

/// <inheritdoc />
public interface IDetailsApi : IApi<PlacesDetailsRequest, PlacesDetailsResponse>;