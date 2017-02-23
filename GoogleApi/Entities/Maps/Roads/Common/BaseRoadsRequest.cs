using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    public class BaseRoadsRequest : BaseMapsRequest, IQueryStringRequest
    {
        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> QueryStringParameters
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