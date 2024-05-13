using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;

namespace GoogleApi.Interfaces.Translate;

/// <inheritdoc />
public interface IDetectApi : IApi<DetectRequest, DetectResponse>;