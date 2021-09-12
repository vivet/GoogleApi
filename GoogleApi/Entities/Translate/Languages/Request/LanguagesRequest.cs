using System.Collections.Generic;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Translate.Languages.Request
{
    /// <summary>
    /// Languages Request.
    /// </summary>
    public class LanguagesRequest : BaseTranslateRequest
    {
        /// <inheritdoc />
        protected internal override string BaseUrl => $"{base.BaseUrl}languages";

        /// <summary>
        /// The target language code for the results.If specified, then the language names are returned in the name field of the response, 
        /// localized in the target language.If you do not supply a target language, then the name field is omitted from the response and only 
        /// the language codes are returned.
        /// </summary>
        public virtual Language? Target { get; set; }

        /// <inheritdoc />
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            parameters.Add("target", this.Target?.ToCode());

            return parameters;
        }
    }
}