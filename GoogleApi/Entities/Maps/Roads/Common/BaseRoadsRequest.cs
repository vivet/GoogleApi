using System;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseRoadsRequest : BaseMapsRequest, IRequestQueryString
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