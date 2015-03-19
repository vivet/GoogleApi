using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class PlacesDetailsResponse : MapsBaseResponse, IResponseFor
    {
        /// <summary>
        /// "results" contains an array of places, with information about the place. See Place Search Results for information about these results. The Places API returns up to 20 establishment results. Additionally, political results may be returned which serve to identify the area of the request.
        /// </summary>
        [DataMember(Name = "result")]
        public virtual Result Result { get; set; }
    }
}
