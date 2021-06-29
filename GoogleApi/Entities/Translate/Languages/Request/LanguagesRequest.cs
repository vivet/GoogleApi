using System;
using System.Collections.Generic;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Translate.Languages.Request
{
    // TODO: VERIFY THAT SERIALIZATION WORKS WHERE NO DEFAULT CONSTRUCTOR. MAYBE JUST MAKE THE DEFAULT CONSTRUCTORS PROTECTED.

    /// <summary>
    /// Languages Request.
    /// </summary>
    public class LanguagesRequest : BaseTranslateRequest
    {
        /// <inheritdoc />
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

        /// <inheritdoc />
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.Target == null)
                throw new ArgumentException($"'{nameof(this.Target)}' is required");

            // TODO: Check docs.
            //if (!this.Target.Value.IsValidNmt())
            //    throw new ArgumentException($"'{nameof(this.Target)}' is not compatible with model 'nmt'");

            // TODO: Seems it should be posted Json, all of the translate endpoints.

            parameters.Add("target", this.Target?.ToCode());
            parameters.Add("model", this.Model.ToString().ToLower());

            return parameters;
        }
    }
}