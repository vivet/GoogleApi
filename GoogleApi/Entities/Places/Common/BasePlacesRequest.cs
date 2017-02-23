using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places requests.
    /// </summary>
    public abstract class BasePlacesRequest : BaseRequest
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "maps.googleapis.com/maps/api/place/";

        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, Request must use SSL"); }
        }

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