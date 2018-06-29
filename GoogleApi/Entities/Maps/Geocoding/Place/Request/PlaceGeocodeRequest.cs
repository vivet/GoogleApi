using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;

namespace GoogleApi.Entities.Maps.Geocoding.Place.Request
{
    /// <summary>
    /// Place Geocoding Request.
    /// </summary>
    public class PlaceGeocodeRequest : BaseGeocodeRequest
    {
        /// <summary>
        /// PlaceId (required).
        /// The place ID of the place for which you wish to obtain the human-readable address. 
        /// The place ID is a unique identifier that can be used with other Google APIs. For example, you can use the placeID returned by the Google Maps Roads API 
        /// to get the address for a snapped point. For more information about place IDs, see the place ID overview. 
        /// The place ID may only be specified if the request includes an API key or a Google Maps APIs Premium Plan client ID.
        /// </summary>
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// result_type — A filter of one or more address types, separated by a pipe (|).
        /// If the parameter contains multiple address types, the API returns all addresses that match any of the types.
        /// A note about processing: The result_type parameter does not restrict the search to the specified address type(s).
        /// Rather, the result_type acts as a post-search filter: the API fetches all results for the specified latlng,
        /// then discards those results that do not match the specified address type(s).
        /// Note: This parameter is available only for requests that include an API key or a client ID. 
        /// </summary>
        public virtual IEnumerable<PlaceLocationType> ResultTypes { get; set; }

        /// <summary>
        /// location_type — A filter of one or more location types, separated by a pipe (|).
        /// If the parameter contains multiple location types, the API returns all addresses that match any of the types.
        /// A note about processing: The location_type parameter does not restrict the search to the specified location type(s).
        /// Rather, the location_type acts as a post-search filter: the API fetches all results for the specified latlng,
        /// then discards those results that do not match the specified location type(s).
        /// Note: This parameter is available only for requests that include an API key or a client ID. 
        /// </summary>
        public virtual IEnumerable<GeometryLocationType> LocationTypes { get; set; }

        /// <summary>
        /// See <see cref="BaseGeocodeRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (this.Key == null)
                throw new ArgumentException("Key is required.");

            if (string.IsNullOrWhiteSpace(this.PlaceId))
                throw new ArgumentException("PlaceId is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("place_id", this.PlaceId);

            if (this.ResultTypes != null && this.ResultTypes.Any())
                parameters.Add("result_type", string.Join("|", this.ResultTypes.AsEnumerable()));

            if (this.LocationTypes != null && this.LocationTypes.Any())
                parameters.Add("location_type", string.Join("|", this.LocationTypes.AsEnumerable()));

            return parameters;
        }
    }
}