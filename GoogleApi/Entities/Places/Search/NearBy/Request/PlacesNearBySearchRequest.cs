using System;
using System.Linq;
using GoogleApi.Entities.Places.Search.Common;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Search.NearBy.Request
{
    /// <summary>
    /// Places NearBySearch Request.
    /// </summary>
    public class PlacesNearBySearchRequest : BasePlacesSearchRequest
    {
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
        public virtual Ranking Rankby { get; set; }

        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "nearbysearch/";
            }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = base.GetQueryStringParameters();

            if (this.Location == null)
                throw new ArgumentException("Location must not be null");

            if (!this.Radius.HasValue)
                throw new ArgumentException("Radius must not be null");

            if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
                throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000.");

            if (this.Rankby == Ranking.DISTANCE && string.IsNullOrWhiteSpace(this.Name) && !this.Types.Any())
                throw new ArgumentException("If rankby=distance is specified, then one or more of keyword, name, or types is required.");

            if (!string.IsNullOrWhiteSpace(this.Name))
                _parameters.Add("name", this.Name);

            if (!string.IsNullOrWhiteSpace(this.Keyword))
                _parameters.Add("keyword", this.Keyword);

            _parameters.Add("rankby", this.Rankby.ToString().ToLower());

            return _parameters;
        }
    }
}