using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;

namespace GoogleApi.Entities.Places.Search.Text.Request
{
    /// <summary>
    /// Places TextSearch Request.
    /// </summary>
    public class PlacesTextSearchRequest : BasePlacesRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "textsearch/json";

        /// <summary>
        /// Query — The text string on which to search, for example: "restaurant". 
        /// The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.
        /// </summary>
        public virtual string Query { get; set; }

        /// <summary>
        /// opennow (optional). 
        /// Returns only those places that are open for business at the time the query is sent. 
        /// Places that do not specify opening hours in the Google Places database will not be returned if you 
        /// include this parameter in your query.
        /// </summary>
        public virtual bool OpenNow { get; set; }

        /// <summary>
        /// (optional) The language in which to return results. See the supported list of domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive. If language is not supplied, 
        /// the Place service will attempt to use the native language of the domain from which the request is sent.
        /// </summary>
        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// Minprice (optional).
        /// Restricts results to only those places within the specified range. 
        /// Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. 
        /// The exact amount indicated by a specific value will vary from region to region.
        /// </summary>
        public virtual PriceLevel? Minprice { get; set; }

        /// <summary>
        /// Maxprice (optional).
        /// Restricts results to only those places within the specified range. 
        /// Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. 
        /// The exact amount indicated by a specific value will vary from region to region.
        /// </summary>
        public virtual PriceLevel? Maxprice { get; set; }

        /// <summary>
        /// Type (optional). 
        /// Restricts the results to places matching the specified type. 
        /// Only one type may be specified (if more than one type is provided, all types following the first entry are ignored). 
        /// </summary>
        public virtual SearchPlaceType? Type { get; set; }

        /// <summary>
        /// Location (optional).
        /// The latitude/longitude around which to retrieve place information. 
        /// If you specify a location parameter, you must also specify a radius parameter.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Radius (Radius).
        /// Defines the distance (in meters) within which to bias place results. The maximum allowed radius is 50 000 meters. 
        /// Results inside of this region will be ranked higher than results outside of the search circle; 
        /// however, prominent results from outside of the search radius may be included
        /// </summary>
        public virtual double? Radius { get; set; }

        /// <summary>
        /// pagetoken — Returns the next 20 results from a previously run search. 
        /// Setting a pagetoken parameter will execute a search with the same parameters 
        /// used previously — all parameters other than pagetoken will be ignored.
        /// </summary>
        public virtual string PageToken { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (!string.IsNullOrEmpty(this.PageToken))
            {
                parameters.Add("pagetoken", this.PageToken);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.Query))
                    throw new ArgumentException("Query is required");

                if (this.Location != null && this.Radius == null)
                    throw new ArgumentException("Radius is required when Location is specified");

                if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
                    throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000");

                parameters.Add("query", this.Query);
                parameters.Add("language", Language.ToCode());

                if (this.Location != null)
                    parameters.Add("location", this.Location.ToString());

                if (this.Radius != null)
                    parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

                if (this.Type.HasValue)
                {
                    var type = this.Type.GetType().GetTypeInfo();
                    var attribute = type.DeclaredMembers.FirstOrDefault(x => x.Name == this.Type.ToString())?.GetCustomAttribute<EnumMemberAttribute>();

                    if (attribute != null)
                        parameters.Add("type", attribute.Value.ToLower());
                }

                if (this.OpenNow)
                    parameters.Add("opennow");

                if (this.Minprice.HasValue)
                    parameters.Add("minprice", ((int)this.Minprice.Value).ToString());

                if (this.Maxprice.HasValue)
                    parameters.Add("maxprice", ((int)this.Maxprice.Value).ToString());
            }
            return parameters;
        }
    }
}