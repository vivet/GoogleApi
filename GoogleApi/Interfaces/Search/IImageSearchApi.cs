using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Image.Request;

namespace GoogleApi.Interfaces.Search;

/// <inheritdoc />
public interface IImageSearchApi : IApi<ImageSearchRequest, BaseSearchResponse>
{

}