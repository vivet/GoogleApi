using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Extensions;

namespace GoogleApi.Entities.Places.Delete.Request
{
    /// <summary>
    /// Places Delete Request.
    /// </summary>
    [DataContract]
    public class PlacesDeleteRequest : BasePlacesRequest, IJsonRequest
    {
        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "delete/json";

        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeid field of a Place request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PlaceId))
                    throw new ArgumentException("PlaceId is required.");

                var parameters = base.QueryStringParameters;

                return parameters;
            }
        }
    }
}