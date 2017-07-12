using System;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class BaseMapsRequest : BaseRequest
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "maps.google.com/maps/api/";
     
        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get => true;
            set => throw new NotSupportedException("This operation is not supported, Request must use SSL");
        }
    }
}