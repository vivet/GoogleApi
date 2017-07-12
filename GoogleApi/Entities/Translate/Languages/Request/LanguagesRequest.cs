using System;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Translate.Languages.Request
{
    /// <summary>
    /// Languages Request.
    /// </summary>
    public class LanguagesRequest : BaseRequest, IQueryStringRequest
    {
        /// <summary>
        /// Base url.
        /// </summary>
        protected internal override string BaseUrl => "translation.googleapis.com/language/translate/v2/languages";

        /// <summary>
        /// The target language code for the results.If specified, then the language names are returned in the name field of the response, 
        /// localized in the target language.If you do not supply a target language, then the name field is omitted from the response and only 
        /// the language codes are returned.
        /// </summary>
        public virtual Language? Target { get; set; }

        /// <summary>
        /// The translation model of the supported languages.
        /// Can be either base to return languages supported by the Phrase-Based Machine Translation(PBMT) model, or nmt to return 
        /// languages supported by the Neural Machine Translation(NMT) model. If omitted, then all supported languages are returned.
        /// Languages supported by the NMT model can only be translated to or from English(en).        
        /// </summary>
        public virtual Model Model { get; set; } = Model.Base;

        /// <summary>
        /// Always true. 
        /// Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get => true;
            set => throw new NotSupportedException("This operation is not supported, SSL is required.");
        }

        /// <summary>
        /// See <see cref="BaseRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Key))
                    throw new ArgumentException("Key is required");

                if (this.Target == null)
                    throw new ArgumentException("Target is required");

                var parameters = base.QueryStringParameters;

                parameters.Add("target", this.Target?.ToCode());
                parameters.Add("model", this.Model.ToString().ToLower());

                return parameters;
            }
        }
    }
}