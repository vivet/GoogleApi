using System;
using GoogleApi.Entities.Search.Common.Request;

namespace GoogleApi.Entities.Search.Enterprise.Request
{
    /// <summary>
    /// Enterprise Search Request.
    /// </summary>
    public class EnterpriseSearchRequest : BaseSearchRequest
    {
        /// <summary>
        /// The URL of a linked custom search engine specification to use for this request. 
        /// Default Google search engine.
        /// </summary>
        public virtual string SearchEngineUrl { get; set; }

        /// <summary>
        /// See <see cref="BaseSearchRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            if (string.IsNullOrEmpty(this.SearchEngineUrl))
                throw new ArgumentException("SearchEngineUrl is required.");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("cref", this.SearchEngineUrl);

            return parameters;
        }
    }
}