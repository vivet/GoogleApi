using System;
using System.Collections.Generic;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Translate
{
    /// <summary>
    /// Base abstract translate request.
    /// </summary>
    public abstract class BaseTranslateRequest : BaseRequest, IRequestQueryString
    {
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
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>A <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Key is required");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}