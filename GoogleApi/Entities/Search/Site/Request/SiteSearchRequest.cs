using System;
using GoogleApi.Entities.Search.Common.Request;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Search.Site.Request
{
    /// <summary>
    /// Site Search Request.
    /// </summary>
    public class SiteSearchRequest : BaseSearchRequest
    {
        /// <summary>
        /// Required. Search engine created for a site with the Google Control Panel (Paid)
        /// </summary>
        public virtual string SearchEngineId { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrEmpty(this.SearchEngineId))
                throw new NullReferenceException("this.SearchEngineId");

            parameters.Add("cx", this.SearchEngineId);

            return parameters;
        }
    }
}