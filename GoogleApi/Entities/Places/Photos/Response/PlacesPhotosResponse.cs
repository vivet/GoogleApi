using System.IO;
using System.Runtime.Serialization;
using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.Photos.Response
{
    /// <summary>
    /// Places Photos Response.
    /// </summary>
    [DataContract]
    public class PlacesPhotosResponse : BasePlacesResponse
    {       
        /// <summary>
        /// 
        /// </summary>
        public MemoryStream Photo { get; set; }        
    }
}