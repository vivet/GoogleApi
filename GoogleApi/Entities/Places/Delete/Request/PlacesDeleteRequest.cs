using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Places.Delete.Request
{
    /// <summary>
    /// Places delete Request.
    /// </summary>
    [DataContract]
    public class PlacesDeleteRequest : BasePlacesRequest, IRequestJson
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "delete/json";

        /// <summary>
        /// A textual identifier that uniquely identifies a place. 
        /// To retrieve information about the place, pass this identifier in the placeid field of a Place request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [DataMember(Name = "place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> colletion.</returns>
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