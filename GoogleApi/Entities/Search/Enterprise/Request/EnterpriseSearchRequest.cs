using System;
using System.Collections.Generic;
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
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> QueryStringParameters
        {
            get
            {
                if (string.IsNullOrEmpty(this.SearchEngineUrl))
                    throw new ArgumentException("SearchEngineUrl is required.");

                var parameters = base.QueryStringParameters;

                parameters.Add("cref", this.SearchEngineUrl);

                return parameters;
            }
        }
    }
}