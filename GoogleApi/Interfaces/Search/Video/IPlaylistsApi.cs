using GoogleApi.Entities.Search.Video.Playlists.Request;
using GoogleApi.Entities.Search.Video.Playlists.Response;

namespace GoogleApi.Interfaces.Search.Video;

/// <inheritdoc />
public interface IPlaylistsApi : IApi<PlaylistSearchRequest, PlaylistSearchResponse>;