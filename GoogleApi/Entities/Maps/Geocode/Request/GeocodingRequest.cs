using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Maps.Geocode.Request
{
    /// <summary>
    /// Geocoding Request.
    /// </summary>
    public class GeocodingRequest : BaseMapsChannelRequest, IRequestQueryString
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "geocode/json";

        /// <summary>
        /// Address (required).
        /// The address that you want to geocode. Required or Location.
        /// If <see cref="PlaceId"/> or <see cref="Location"/> is specified, this is ignored.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// PlaceId (required).
        /// The place ID of the place for which you wish to obtain the human-readable address. 
        /// The place ID is a unique identifier that can be used with other Google APIs. For example, you can use the placeID returned by the Google Maps Roads API 
        /// to get the address for a snapped point. For more information about place IDs, see the place ID overview. 
        /// The place ID may only be specified if the request includes an API key or a Google Maps APIs Premium Plan client ID.
        /// </summary>
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Latlng (required).
        /// The textual latitude/longitude value for which you wish to obtain the closest, human-readable address.
        /// If you pass a latlng, the geocoder performs what is known as a reverse geocode. See Reverse Geocoding for more information.
        /// If <see cref="PlaceId"/> is specified, this is ignored.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// bounds (optional) — The bounding box of the viewport within which to bias geocode results more prominently. (For more information see Viewport Biasing below.)
        /// The bounds and region parameters will only influence, not fully restrict, results from the geocoder.
        /// </summary>
        public virtual Location[] Bounds { get; set; }

        /// <summary>
        /// region (optional) — The region code, specified as a ccTLD ("top-level domain") two-character value. (For more information see Region Biasing below.)
        /// The bounds and region parameters will only influence, not fully restrict, results from the geocoder.
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results. 
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. 
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// The component filters, separated by a pipe (|). Each component filter consists of a component:value pair and will fully restrict the results from the geocoder. For more information see Component Filtering.
        /// </summary>
        public virtual Dictionary<Component, string> Components { get; set; }

        /// <summary>
        /// See <see cref="BaseMapsChannelRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (this.Location == null && string.IsNullOrWhiteSpace(this.PlaceId) && string.IsNullOrWhiteSpace(this.Address))
                throw new ArgumentException("Location, PlaceId or Address is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("language", this.Language.ToCode());

            if (this.PlaceId != null)
            {
                if (this.Key == null)
                    throw new ArgumentException("Key is required, when using PlaceId");

                parameters.Add("place_id", this.PlaceId);
            }
            else if (this.Location != null)
                parameters.Add("latlng", this.Location.ToString());
            else
                parameters.Add("address", this.Address);

            if (this.Bounds != null && this.Bounds.Any())
                parameters.Add("bounds", string.Join("|", this.Bounds.AsEnumerable()));

            if (!string.IsNullOrWhiteSpace(this.Region))
                parameters.Add("region", this.Region);

            if (this.Components != null && this.Components.Any())
                parameters.Add("components", string.Join("|", this.Components.Select(x => $"{x.Key.ToString().ToLower()}:{x.Value}")));

            return parameters;
        }
    }
}