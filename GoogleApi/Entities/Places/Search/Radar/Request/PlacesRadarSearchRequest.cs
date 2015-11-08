using System;
using System.Linq;
using GoogleApi.Entities.Places.Search.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Search.Radar.Request
{
    /// <summary>
    /// PlacesRadarSearch Request.
    /// A Radar Search request must include at least one of keyword, name, or types.
    /// </summary>
    public class PlacesRadarSearchRequest : BasePlacesSearchRequest
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

        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "radarsearch/";
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

            if (string.IsNullOrWhiteSpace(this.Keyword) && string.IsNullOrWhiteSpace(this.Name) && !this.Types.Any())
                throw new ArgumentException("Request must include at least one of keyword, name, or types");

            if (!string.IsNullOrWhiteSpace(this.Name))
                _parameters.Add("name", this.Name);

            if (!string.IsNullOrWhiteSpace(this.Keyword))
                _parameters.Add("keyword", this.Keyword);

            return _parameters;
        }
    }
}