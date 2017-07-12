using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Translate.Detect.Request
{
    /// <summary>
    /// Detect Request.
    /// </summary>
    public class DetectRequest : BaseRequest, IQueryStringRequest
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