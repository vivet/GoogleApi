using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using GoogleApi.Extensions;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Translate.Translate.Request
{
    public class TranslateRequest : BaseRequest
    {
        private Format _format = Format.Html;
        private bool _prettyPrint = true;

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
        public virtual bool PrettyPrint
        {
            get { return _prettyPrint; }
            set { _prettyPrint = value; }
        }

        /// <summary>
        /// This optional parameter allows you to indicate that the text to be translated is either plain-text or HTML. A value of html indicates HTML and a value of text indicates plain-text.
        /// Default: format=html.
        /// </summary>
        public virtual Format Format
        {
            get { return _format; }
            set { _format = value; }
        }


        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, TimeZoneRequest must use SSL"); }
        }


        public override Uri GetUri()
        {
            var scheme = IsSsl ? "https://" : "http://";
            var queryString = GetQueryStringParameters().ToQueryString();
            return new Uri(scheme + BaseUrl + "?" + queryString);
        }

        protected override IDictionary<string, string> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("ApiKey is required");

            if (string.IsNullOrWhiteSpace(Target))
                throw new ArgumentException("ApiKey is required");

            if (Qs == null || !Qs.Any())
                throw new ArgumentException("Qs is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("key", ApiKey);
            parameters.Add("target", Target);

            foreach (var q in Qs)
            {
                parameters.Add("q", q);
            }

            parameters.Add("prettyprint", PrettyPrint.ToString().ToLower());
            parameters.Add("format", Format.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(Source))
                parameters.Add("source", Source);

            return parameters;
        }
    }
}