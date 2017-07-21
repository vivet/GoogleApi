using System;
using GoogleApi.Entities.Interfaces;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Delete.Request
{
    /// <summary>
    /// Places delete Request.
    /// </summary>
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
        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.PlaceId))
                throw new ArgumentException("PlaceId is required");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}