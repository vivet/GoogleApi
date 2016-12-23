using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Delete.Request
{
    /// <summary>
    /// Places Delete Request.
    /// </summary>
    [DataContract]
    public class PlacesDeleteRequest : BasePlacesRequest
    {
        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeid field of a Place request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// A unique token that you can use to retrieve additional information about this place. 
        /// Note: Alternatively, you can specify a reference to identify the place. Note that the reference is deprecated in favor of place_id. See the deprecation notice on this page.
        /// </summary>
        [DataMember(Name = "reference")]
        public virtual string Reference { get; set; }

        /// <summary>
        /// True to use use the https protocol; false to use http. The default is false.
        /// </summary>
        public override bool IsJson
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotSupportedException("This operation is not supported, Request must use SSL");
            }
        }

        protected internal override string BaseUrl
        {
            get { return base.BaseUrl + "delete/"; }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.PlaceId) && string.IsNullOrWhiteSpace(this.Reference))
                throw new ArgumentException("PlaceId or Reference must be provided.");

            return _parameters;
        }
    }
}