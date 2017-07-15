using System;
using System.Globalization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Search.Text.Request
{
    /// <summary>
    /// Places TextSearch Request.
    /// </summary>
    public class PlacesTextSearchRequest : BasePlacesSearchRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "textsearch/json";

        /// <summary>
        /// Query — The text string on which to search, for example: "restaurant". 
        /// The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Radius (Radius).
        /// Defines the distance (in meters) within which to bias place results. The maximum allowed radius is 50 000 meters. 
        /// Results inside of this region will be ranked higher than results outside of the search circle; 
        /// however, prominent results from outside of the search radius may be included
        /// </summary>
        public virtual double? Radius { get; set; }

        /// <summary>
        /// Location (optional).
        /// The latitude/longitude around which to retrieve place information. 
        /// This must be specified as latitude,longitude. 
        /// If you specify a location parameter, you must also specify a radius parameter.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesSearchRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Query))
                    throw new ArgumentException("Query is required");

                if (this.Location != null && this.Radius == null)
                    throw new ArgumentException("Radius is required when Location is specified");

                var parameters = base.QueryStringParameters;

                parameters.Add("query", this.Query);

                if (this.Location != null)
                    parameters.Add("location", this.Location.ToString());

                if (this.Radius != null)
                    parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

                return parameters;
            }
        }
    }
}