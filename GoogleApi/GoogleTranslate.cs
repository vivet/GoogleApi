using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Languages.Response;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;
using System.Net.Http;

namespace GoogleApi
{
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
        ///
        /// </summary>
        public sealed class TranslateApi : HttpEngine<TranslateRequest, TranslateResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public TranslateApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public TranslateApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class DetectApi : HttpEngine<DetectRequest, DetectResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public DetectApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public DetectApi(HttpClient client) : base(client) { }
        }

        /// <summary>
        ///
        /// </summary>
        public sealed class LanguagesApi : HttpEngine<LanguagesRequest, LanguagesResponse>
        {
            /// <summary>
            ///
            /// </summary>
            public LanguagesApi() { }

            /// <summary>
            ///
            /// </summary>
            /// <param name="client"></param>
            public LanguagesApi(HttpClient client) : base(client) { }
        }
    }
}