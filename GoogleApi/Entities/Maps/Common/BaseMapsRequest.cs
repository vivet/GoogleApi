using System;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class BaseMapsRequest : SignableRequest
    {
        private const string BASE_URL = "maps.google.com/maps/api/";

        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotSupportedException("This operation is not supported, PlacesRequest must use SSL");
            }
        }

        protected internal override string BaseUrl
        {
            get
            {
                return BaseMapsRequest.BASE_URL;
            }
        }
    }
}
