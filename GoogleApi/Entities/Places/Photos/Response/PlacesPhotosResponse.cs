using System.IO;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Photos.Response
{
    /// <summary>
    /// Places Photos Response.
    /// </summary>
    [DataContract]
    public class PlacesPhotosResponse : BasePlacesResponse
    {
        /// <summary>
        /// A stream containing the downloded photo.
        /// </summary>
        public virtual MemoryStream Photo { get; set; }

        /// <summary>
        /// A string containing the downloded photo.
        /// </summary>
        [DataMember(Name = "photo")]
        protected virtual byte[] PhotoStr
        {
            get => this.Photo.ToArray();
            set => this.Photo = new MemoryStream(value);
        }
    }
}