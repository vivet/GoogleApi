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
        /// address (required) — The address that you want to geocode. Required or Location.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// latlng (required) — The textual latitude/longitude value for which you wish to obtain the closest, human-readable address.
        /// If you pass a latlng, the geocoder performs what is known as a reverse geocode. See Reverse Geocoding for more information.
        /// Required or Address.
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
            if (this.Location == null && string.IsNullOrWhiteSpace(this.Address))
                throw new ArgumentException("Location or Address is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("language", this.Language.ToCode());

            if (this.Location != null)
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