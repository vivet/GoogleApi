using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Photos.Response;

namespace GoogleApi.Interfaces.Places;

/// <inheritdoc />
public interface IPhotosApi : IApi<PlacesPhotosRequest, PlacesPhotosResponse>;