using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Translate.Translate.Request
{
    public class TranslateRequest : BaseRequest
    {
        protected internal override string BaseUrl
        {
            get { return "www.googleapis.com/language/translate/v2"; }
        }

        /// <summary>
        /// Your application's API key. This key identifies your application for purposes of quota management and so that Places 
        /// added from your application are made immediately available to your app. Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        public virtual string ApiKey { get; set; }

        /// <summary>
        /// Use the Source query parameter to specify the language you want to translate from. (optional)
        /// </summary>
        public virtual string Source { get; set; }

        /// <summary>
        /// Use the target query parameter to specify the language you want to translate into.
        /// </summary>
        public virtual string Target { get; set; } 

        /// <summary>
        /// Use the q query parameter to identify the string to translate
        /// </summary>
        public virtual IEnumerable<string> Qs { get; set; } 

        /// <summary>
        /// If prettyprint=true, the results returned by the server will be human readable (pretty printed).
        /// Default: prettyprint=true.
        /// </summary>
        public virtual bool PrettyPrint { get; set; } 

        /// <summary>
        /// This optional parameter allows you to indicate that the text to be translated is either plain-text or HTML. A value of html indicates HTML and a value of text indicates plain-text.
        /// Default: format=html.
        /// </summary>
        public virtual Format Format { get; set; } 

        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, TimeZoneRequest must use SSL"); }
        }

        public TranslateRequest()
        {
            this.Format = Format.Html;
            this.PrettyPrint = true;
        }

        public override Uri GetUri()
        {
            var _scheme = this.IsSsl ? "https://" : "http://";
            var _queryString = this.GetQueryStringParameters().GetQueryStringPostfix();
            return new Uri(_scheme + this.BaseUrl + "?" + _queryString);
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.ApiKey))
                throw new ArgumentException("ApiKey is required");

            if (string.IsNullOrWhiteSpace(this.Target))
                throw new ArgumentException("ApiKey is required");

            if (this.Qs == null || !this.Qs.Any())
                throw new ArgumentException("Qs is required");

            var _parameters = base.GetQueryStringParameters();

            _parameters.Add("key", this.ApiKey);
            _parameters.Add("target", this.Target);

            foreach (var _q in this.Qs)
            {
                _parameters.Add("q", _q);
            }

            _parameters.Add("prettyprint", this.PrettyPrint.ToString().ToLower());
            _parameters.Add("format", this.Format.ToString().ToLower());
            
            if (!string.IsNullOrWhiteSpace(this.Source))
                _parameters.Add("source", this.Source);

            return _parameters;
        }
    }
}