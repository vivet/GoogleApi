using System;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Roads
{
    /// <summary>
    /// Base abstract roads request.
    /// </summary>
    public abstract class BaseRoadsRequest : BaseMapsRequest, IRequestQueryString
    {
        /// <summary>
        /// See <see cref="BaseRequest.QueryStringParameters"/>
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Key))
                    throw new ArgumentException("Key is required");

                var parameters = base.QueryStringParameters;

                return parameters;
            }
        }
    }
}