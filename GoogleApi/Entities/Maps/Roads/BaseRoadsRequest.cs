using System;
using System.Collections.Generic;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.Roads
{
    /// <summary>
    /// Base abstract roads request.
    /// </summary>
    public abstract class BaseRoadsRequest : BaseMapsRequest, IRequestQueryString
    {
        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Key is required");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}