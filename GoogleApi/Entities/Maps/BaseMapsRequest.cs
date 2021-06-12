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
        protected internal override string BaseUrl => "maps.googleapis.com/maps/api/";
    }
}