using GoogleApi.Engine;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;

namespace GoogleApi
{
    /// <summary>
    /// Methods to access Google Translate Api: https://developers.google.com/translate/v2/getting_started
    /// </summary>
    public class GoogleTranslate
    {
        /// <summary>Perform places text search operations.</summary>
        public static EngineFacade<TranslateRequest, TranslateResponse> Translate
        {
            get
            {
                return EngineFacade<TranslateRequest, TranslateResponse>._instance;
            }
        }
    }
}