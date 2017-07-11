using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Translate.Translate.Request
{
    /// <summary>
    /// Translate Request.
    /// </summary>
    public class TranslateRequest : BaseRequest, IQueryStringRequest
    {
        /// <summary>
        /// Base url.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/language/translate/v2";

        /// <summary>
        /// The language of the source text, set to one of the language codes listed in Language Support. 
        /// If the source language is not specified, the API will attempt to detect the source language automatically and 
        /// return it within the response.
        /// </summary>
        public virtual Language? Source { get; set; }

        /// <summary>
        /// Required. The language to use for translation of the input text, 
        /// set to one of the language codes listed in Language Support.
        /// </summary>
        public virtual Language? Target { get; set; }

        /// <summary>
        /// The translation model. 
        /// Can be either base to use the Phrase-Based Machine Translation (PBMT) model, 
        /// or nmt to use the Neural Machine Translation (NMT) model. If omitted, then nmt is used.
        /// If the model is nmt, and the requested language translation pair is not supported for the NMT model, 
        /// then the request is translated using the base model.
        /// Languages supported by the NMT model can only be translated to or from English(en).
        /// </summary>
        public virtual Model Model { get; set; } = Model.Base;

        /// <summary>
        /// The format of the source text, in either HTML (default) or plain-text. 
        /// A value of html indicates HTML and a value of text indicates plain-text.
        /// Default: format=html.
        /// </summary>
        public virtual Format Format { get; set; } = Format.Html;

        /// <summary>
        /// Required. The input text to translate. 
        /// Repeat this parameter to perform translation operations on multiple text inputs.
        /// </summary>
        public virtual IEnumerable<string> Qs { get; set; }

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
                    throw new ArgumentException("Key is required.");

                if (this.Target == null)
                    throw new ArgumentException("Target is required");

                if (this.Qs == null || !this.Qs.Any())
                    throw new ArgumentException("Qs is required");

                if (this.Model == Model.Nmt)
                {
                    if (this.Source != null && !this.Source.Value.IsValidNmt())
                        throw new ArgumentException("Source is not compatible with model 'nmt'");

                    if (!this.Target.Value.IsValidNmt())
                        throw new ArgumentException("Target is not compatible with model 'nmt'");

                    if (this.Source != null && this.Source != Language.English && this.Target != Language.English)
                        throw new ArgumentException("Source or Target must be english");
                }

                var parameters = base.QueryStringParameters;

                parameters.Add("target", this.Target?.ToCode());
                parameters.Add("model", this.Model.ToString().ToLower());
                parameters.Add("format", this.Format.ToString().ToLower());

                if (this.Source != null)
                    parameters.Add("source", this.Source?.ToCode());

                foreach (var q in this.Qs)
                {
                    parameters.Add("q", q);
                }

                return parameters;
            }
        }
    }
}