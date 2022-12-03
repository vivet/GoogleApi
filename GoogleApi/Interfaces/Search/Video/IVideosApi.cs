using GoogleApi.Entities.Search.Video.Videos.Request;
using GoogleApi.Entities.Search.Video.Videos.Response;

namespace GoogleApi.Interfaces.Search.Video;

/// <inheritdoc />
public interface IVideosApi : IApi<VideoSearchRequest, VideoSearchResponse>
{

}