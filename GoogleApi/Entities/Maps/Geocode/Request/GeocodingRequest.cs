using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Geocode.Request
{
    public class GeocodingRequest : SignableRequest
	{
		protected internal override string BaseUrl
		{
			get
			{
				return base.BaseUrl + "geocode/";
			}
		}

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
		/// language (optional) — The language in which to return results. See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive. If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
		/// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// The component filters, separated by a pipe (|). Each component filter consists of a component:value pair and will fully restrict the results from the geocoder. For more information see Component Filtering.
		/// </summary>
        public virtual Dictionary<Component, string> Components { get; set; }

		protected override QueryStringParametersList GetQueryStringParameters()
		{
            if (Location == null && string.IsNullOrWhiteSpace(Address))
				throw new ArgumentException("Location OR Address is required");

			var parameters = base.GetQueryStringParameters();

            if (Location != null)
                parameters.Add("latlng", Location.ToString());
			else
                parameters.Add("address", Address);

            if (Bounds != null && Bounds.Any())
                parameters.Add("bounds", string.Join("|", Bounds.AsEnumerable()));

            if (!string.IsNullOrWhiteSpace(Region))
                parameters.Add("region", Region);

            if (!string.IsNullOrWhiteSpace(Language))
                parameters.Add("language", Language);

            if (Components != null && Components.Any())
                parameters.Add("components", string.Join("|", Components.Select(x => string.Format("{0}:{1}", x.Key, x.Value))));

			return parameters;
		}
	}
}
