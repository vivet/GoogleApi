using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;

namespace GoogleApi.Entities.Places.Search.NearBy.Request
{
    /// <summary>
    /// Places NearBySearch Request.
    /// </summary>
    public class PlacesNearBySearchRequest : BasePlacesRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "nearbysearch/json";

        /// <summary>
        /// name — One or more terms to be matched against the names of places, separated with a space character. 
        /// Results will be restricted to those containing the passed name values. Note that a place may have additional names associated with it, beyond its listed name. 
        /// The API will try to match the passed name value against all of these names. As a result, places may be returned in the results whose listed names do not match the search term, 
        /// but whose associated names do.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// keyword — A term to be matched against all content that Google has indexed for this place, including but not limited to name, type, and address, 
        /// as well as customer reviews and other third-party content.
        /// </summary>
        public virtual string Keyword { get; set; }

        /// <summary>
        /// rankby — Specifies the order in which results are listed. Possible values are:
        /// - prominence (default). 
        /// This option sorts results based on their importance. Ranking will favor prominent places within the specified area. 
        /// - Prominence, can be affected by a place's ranking in Google's index, global popularity, and other factors.
        /// - Distance. This option biases search results in ascending order by their distance from the specified location. When distance is specified, one or more of keyword, name, or types is required.
        /// If rankby=distance is specified, then one or more of keyword, name, or types is required.
        /// </summary>
        public virtual Ranking Rankby { get; set; } = Ranking.Prominence;

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
        public virtual Coordinate Location { get; set; }

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
                if (this.Location == null)
                    throw new ArgumentException("Location is required");

                if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
                    throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000");

                if (this.Rankby == Ranking.Distance)
                {
                    if (this.Radius.HasValue)
                        throw new ArgumentException("Radius cannot be specified, when using RankBy distance");

                    if (string.IsNullOrWhiteSpace(this.Name) && string.IsNullOrWhiteSpace(this.Keyword) && !this.Type.HasValue)
                        throw new ArgumentException("Keyword, Name or Type is required, If rank by distance");
                }
                else
                {
                    if (!this.Radius.HasValue)
                        throw new ArgumentException("Radius is required, when RankBy is not Distance");
                }

                if (!string.IsNullOrWhiteSpace(this.Name))
                    parameters.Add("name", this.Name);

                if (!string.IsNullOrWhiteSpace(this.Keyword))
                    parameters.Add("keyword", this.Keyword);

                parameters.Add("rankby", this.Rankby.ToString().ToLower());
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