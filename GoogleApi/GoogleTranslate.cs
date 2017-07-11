using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Languages.Response;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;

namespace GoogleApi
{
    /// <summary>
    /// Google Translate dynamically translates text between thousands of language pairs.
    /// https://cloud.google.com/translate/docs/reference/rest
    /// Supported Languages: https://cloud.google.com/translate/docs/languages
    /// </summary>
    public class GoogleTranslate
    {
        /// <summary>
        /// Translates input text, returning translated text.
        /// https://cloud.google.com/translate/docs/reference/translate
        /// </summary>
        public static HttpEngine<TranslateRequest, TranslateResponse> Translate => HttpEngine<TranslateRequest, TranslateResponse>.instance;

        /// <summary>
        /// Detects the language of text within a request.
        /// https://cloud.google.com/translate/docs/reference/detect
        /// </summary>
        public static HttpEngine<DetectRequest, DetectResponse> Detect => HttpEngine<DetectRequest, DetectResponse>.instance;

        /// <summary>
        /// Returns a list of supported languages for translation.
        /// https://cloud.google.com/translate/docs/reference/languages
        /// </summary>
        public static HttpEngine<LanguagesRequest, LanguagesResponse> Languages => HttpEngine<LanguagesRequest, LanguagesResponse>.instance;
    }
}