using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Details.Response
{
    /// <summary>
    /// Places Details Response.
    /// </summary>
    [DataContract]
    public class PlacesDetailsResponse : BasePlacesResponse
    {
        /// <summary>
        /// Results contains an array of places, with information about the place. 
        /// See Place Search Results for information about these results. 
        /// The Places API returns up to 20 establishment results. Additionally, political results may be returned which serve to identify the area of the request.
        /// </summary>
        [JsonProperty("result")]
        public virtual DetailsResult Result { get; set; }

        /// <summary>
        /// html_attributions contain a set of attributions which must be displayed to the user.
        /// </summary>
        [JsonProperty("html_attributions")]
        public virtual IEnumerable<string> HtmlAttributions { get; set; }
    }
}