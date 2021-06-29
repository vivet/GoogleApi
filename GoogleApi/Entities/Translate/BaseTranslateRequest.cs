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
        /// <inheritdoc />
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException($"'{nameof(this.Key)}' is required");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}