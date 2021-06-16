using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;

namespace GoogleApi.Entities.Maps.Geocoding.Location.Request
{
    /// <summary>
    /// Reverse Geocoding Request.
    /// </summary>
    public class LocationGeocodeRequest : BaseGeocodeRequest, IRequestQueryString
    {
        /// <summary>
        /// Latlng (required).
        /// The textual latitude/longitude value for which you wish to obtain the closest, human-readable address.
        /// If you pass a latlng, the geocoder performs what is known as a reverse geocode.
        /// </summary>
        public virtual Coordinate Location { get; set; }

        /// <summary>
        /// result_type — A filter of one or more address types, separated by a pipe (|).
        /// If the parameter contains multiple address types, the API returns all addresses that match any of the types.
        /// A note about processing: The result_type parameter does not restrict the search to the specified address type(s).
        /// Rather, the result_type acts as a post-search filter: the API fetches all results for the specified latlng,
        /// then discards those results that do not match the specified address type(s).
        /// Note: This parameter is available only for requests that include an API key or a client ID. 
        /// </summary>
        public virtual IEnumerable<PlaceLocationType> ResultTypes { get; set; } = new List<PlaceLocationType>();

        /// <summary>
        /// location_type — A filter of one or more location types, separated by a pipe (|).
        /// If the parameter contains multiple location types, the API returns all addresses that match any of the types.
        /// A note about processing: The location_type parameter does not restrict the search to the specified location type(s).
        /// Rather, the location_type acts as a post-search filter: the API fetches all results for the specified latlng,
        /// then discards those results that do not match the specified location type(s).
        /// Note: This parameter is available only for requests that include an API key or a client ID. 
        /// </summary>
        public virtual IEnumerable<GeometryLocationType> LocationTypes { get; set; } = new List<GeometryLocationType>();

        /// <inheritdoc />
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.Location == null)
                throw new ArgumentException($"'{nameof(this.Location)}' is required");

            parameters.Add("latlng", this.Location.ToString());

            if (this.ResultTypes != null && this.ResultTypes.Any())
            {
                parameters.Add("result_type", string.Join("|", this.ResultTypes.Select(x => x.ToString().ToLower())));
            }

            if (this.LocationTypes != null && this.LocationTypes.Any())
            {
                parameters.Add("location_type", string.Join("|", this.LocationTypes.Select(x => x.ToString().ToUpper())));
            }

            return parameters;
        }
    }
}