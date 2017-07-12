using System;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseRoadsRequest : BaseMapsRequest, IQueryStringRequest
    {
        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Key))
                    throw new ArgumentException("Key is required.");

                var parameters = base.QueryStringParameters;

                return parameters;
            }
        }
    }
}