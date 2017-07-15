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
        /// "results" contains an array of places, with information about the place. See Place Search Results for information about these results. 
        /// The Places API returns up to 20 establishment results. Additionally, political results may be returned which serve to identify the area of the request.
        /// </summary>
        [JsonProperty("result")]
        public virtual DetailsResult Result { get; set; }
    }
}