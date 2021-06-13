using System;
using System.Collections.Generic;

namespace GoogleApi.Entities.Maps
{
    /// <summary>
    /// Base abstract class for maps requests.
    /// </summary>
    public abstract class BaseMapsRequest : BaseRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => "maps.googleapis.com/maps/api/";

        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>A <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrEmpty(this.Key))
                throw new ArgumentException($"'{nameof(this.Key)}' is required");

            return parameters;
        }
    }
}