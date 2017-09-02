using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Places.Search.Radar.Request
{
    /// <summary>
    /// PlacesRadarSearch Request.
    /// A Radar Search request must include at least one of keyword, name, or types.
    /// </summary>
    public class PlacesRadarSearchRequest : BasePlacesSearchRequest
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => base.BaseUrl + "radarsearch/json";

        /// <summary>
        /// name — One or more terms to be matched against the names of places, separated with a space character. 
        /// Results will be restricted to those containing the passed name values. 
        /// Note that a place may have additional names associated with it, beyond its listed name. 
        /// The API will try to match the passed name value against all of these names. As a result, places may be returned in the results 
        /// whose listed names do not match the search term, but whose associated names do.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// keyword — A term to be matched against all content that Google has indexed for this place, 
        /// including but not limited to name, type, and address, as well as customer reviews and other third-party content.
        /// </summary>
        public virtual string Keyword { get; set; }
        
        /// <summary>
        /// See <see cref="BasePlacesSearchRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (this.Location == null)
                throw new ArgumentException("Location is required");

            if (this.Radius == null)
                throw new ArgumentException("Radius is required");

            if (string.IsNullOrWhiteSpace(this.Keyword) && string.IsNullOrWhiteSpace(this.Name) && !this.Type.HasValue)
                throw new ArgumentException("Keyword, Name or Type is required");

            var parameters = base.GetQueryStringParameters();

            if (!string.IsNullOrWhiteSpace(this.Name))
                parameters.Add("name", this.Name);

            if (!string.IsNullOrWhiteSpace(this.Keyword))
                parameters.Add("keyword", this.Keyword);

            return parameters;
        }
    }
}