using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Languages.Response;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;
using System.Net.Http;
using GoogleApi.Interfaces.Translate;

namespace GoogleApi;

/// <summary>
/// Google Translate dynamically translates text between thousands of language pairs.
/// https://cloud.google.com/translate/docs/reference/rest
/// Supported Languages: https://cloud.google.com/translate/docs/languages
/// </summary>
public partial class GoogleTranslate
{
    /// <summary>
    /// Translates input text, returning translated text.
    /// https://cloud.google.com/translate/docs/reference/translate
    /// </summary>
    public static TranslateApi Translate => new();

    /// <summary>
    /// Detects the language of text within a request.
    /// https://cloud.google.com/translate/docs/reference/detect
    /// </summary>
    public static DetectApi Detect => new();

    /// <summary>
    /// Returns a list of supported languages for translation.
    /// https://cloud.google.com/translate/docs/reference/languages
    /// </summary>
    public static LanguagesApi Languages => new();
}

public partial class GoogleTranslate
{
    /// <summary>
    /// Translate Api.
    /// </summary>
    public sealed class TranslateApi : HttpEngine<TranslateRequest, TranslateResponse>, ITranslateApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TranslateApi()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public TranslateApi(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }

    /// <summary>
    /// Detect Api.
    /// </summary>
    public sealed class DetectApi : HttpEngine<DetectRequest, DetectResponse>, IDetectApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DetectApi()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public DetectApi(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }

    /// <summary>
    /// Languages Api.
    /// </summary>
    public sealed class LanguagesApi : HttpEngine<LanguagesRequest, LanguagesResponse>, ILanguagesApi
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public LanguagesApi()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        public LanguagesApi(HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}