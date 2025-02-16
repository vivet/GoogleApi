using GoogleApi.Entities.PlacesNew.Photos.Request;
using GoogleApi.Entities.PlacesNew.Photos.Response;

namespace GoogleApi.Interfaces.PlacesNew;

/// <inheritdoc />
public interface IPhotosNewApi : IApi<PlacesNewPhotosRequest, PlacesNewPhotosResponse>;