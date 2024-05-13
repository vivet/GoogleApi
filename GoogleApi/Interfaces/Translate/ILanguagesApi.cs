using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Languages.Response;

namespace GoogleApi.Interfaces.Translate;

/// <inheritdoc />
public interface ILanguagesApi : IApi<LanguagesRequest, LanguagesResponse>;