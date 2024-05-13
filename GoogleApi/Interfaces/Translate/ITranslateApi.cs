using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;

namespace GoogleApi.Interfaces.Translate;

/// <inheritdoc />
public interface ITranslateApi : IApi<TranslateRequest, TranslateResponse>;