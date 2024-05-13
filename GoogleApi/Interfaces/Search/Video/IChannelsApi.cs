using GoogleApi.Entities.Search.Video.Channels.Request;
using GoogleApi.Entities.Search.Video.Channels.Response;

namespace GoogleApi.Interfaces.Search.Video;

/// <inheritdoc />
public interface IChannelsApi : IApi<ChannelSearchRequest, ChannelSearchResponse>;