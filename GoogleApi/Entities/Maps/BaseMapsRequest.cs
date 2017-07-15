using System;
using Newtonsoft.Json;

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
        protected internal override string BaseUrl => "maps.google.com/maps/api/";

        /// <summary>
        /// Always true. 
        /// Setter is not supported.
        /// </summary>
        [JsonIgnore]
        public override bool IsSsl
        {
            get => true;
            set => throw new NotSupportedException("This operation is not supported, Request must use SSL");
        }
    }
}