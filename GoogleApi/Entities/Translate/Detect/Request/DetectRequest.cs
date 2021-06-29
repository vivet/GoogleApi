using GoogleApi.Entities.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Entities.Translate.Detect.Request
{
    /// <summary>
    /// Detect Request.
    /// </summary>
    public class DetectRequest : BaseTranslateRequest
    {
        /// <inheritdoc />
        protected internal override string BaseUrl => "translation.googleapis.com/language/translate/v2/detect";

        /// <summary>
        /// Required. The input text upon which to perform language detection. 
        /// Repeat this parameter to perform language detection on multiple text inputs.
        /// </summary>
        public virtual IEnumerable<string> Qs { get; set; }

        /// <inheritdoc />
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.Qs == null || !this.Qs.Any())
                throw new ArgumentException($"'{nameof(this.Qs)}' is required");

            foreach (var q in this.Qs)
            {
                parameters.Add("q", q);
            }

            return parameters;
        }
    }
}