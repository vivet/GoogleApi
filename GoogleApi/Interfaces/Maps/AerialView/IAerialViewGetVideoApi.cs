using GoogleApi.Entities.Maps.AerialView.GetVideo.Request;
using GoogleApi.Entities.Maps.AerialView.GetVideo.Response;

namespace GoogleApi.Interfaces.Maps.AerialView;

/// <inheritdoc />
public interface IAerialViewGetVideoApi : IApi<GetVideoRequest, GetVideoResponse>;