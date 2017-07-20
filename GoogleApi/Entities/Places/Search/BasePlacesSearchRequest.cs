using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;

namespace GoogleApi.Entities.Places.Search
{
    /// <summary>
    /// PlacesBaseSearch Request.
    /// Base abstract class for places search.
    /// </summary>
    public abstract class BasePlacesSearchRequest : BasePlacesRequest, IRequestQueryString
    {
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
        /// pagetoken — Returns the next 20 results from a previously run search. 
        /// Setting a pagetoken parameter will execute a search with the same parameters 
        /// used previously — all parameters other than pagetoken will be ignored.
        /// </summary>
        public virtual string PageToken { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                var parameters = base.QueryStringParameters;

                parameters.Add("language", Language.ToCode());

                if (this.Type.HasValue)
                    parameters.Add("type", this.Type.Value.ToString().ToLower());

                if (this.OpenNow)
                    parameters.Add("opennow");

                if (this.Minprice.HasValue)
                    parameters.Add("minprice", this.Minprice.Value.ToString().ToLower());

                if (this.Maxprice.HasValue)
                    parameters.Add("maxprice", this.Maxprice.Value.ToString().ToLower());

                if (!string.IsNullOrWhiteSpace(this.PageToken))
                    parameters.Add("pagetoken", this.PageToken);

                return parameters;
            }
        }
    }
}