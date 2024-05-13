using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Web.Request;

namespace GoogleApi.Interfaces.Search;

/// <inheritdoc />
public interface IWebSearchApi : IApi<WebSearchRequest, BaseSearchResponse>;