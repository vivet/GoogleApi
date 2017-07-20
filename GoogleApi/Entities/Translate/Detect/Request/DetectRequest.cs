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
        /// <summary>
        /// Base url.
        /// </summary>
        protected internal override string BaseUrl => "translation.googleapis.com/language/translate/v2/detect";

        /// <summary>
        /// Required. The input text upon which to perform language detection. 
        /// Repeat this parameter to perform language detection on multiple text inputs.
        /// </summary>
        public virtual IEnumerable<string> Qs { get; set; }

        /// <summary>
        /// See <see cref="BaseTranslateRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (this.Qs == null || !this.Qs.Any())
                    throw new ArgumentException("Qs is required");

                var parameters = base.QueryStringParameters;

                foreach (var q in this.Qs)
                {
                    parameters.Add("q", q);
                }

                return parameters;
            }
        }
    }
}