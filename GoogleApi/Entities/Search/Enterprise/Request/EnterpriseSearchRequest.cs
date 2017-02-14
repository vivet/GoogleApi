using System;
using GoogleApi.Entities.Search.Common.Request;
using GoogleApi.Helpers;

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
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrEmpty(this.SearchEngineUrl))
                throw new ArgumentException("SearchEngineUrl must not null.");

            parameters.Add("cref", this.SearchEngineUrl);

            return parameters;
        }
    }
}