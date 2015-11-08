using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Place Photo.
    /// </summary>
    [DataContract]
    public class Photo
    {        
        /// <summary>
        /// PhotoReference — a string used to identify the photo when you perform a Photo request.
        /// </summary>
        [DataMember(Name = "photo_reference")]
        public virtual string PhotoReference { get; set; }
        
        /// <summary>
        /// Height — the maximum height of the image.
        /// </summary>
        [DataMember(Name = "height")]
        public virtual int Height { get; set; }
        
        /// <summary>
        /// Width — the maximum width of the image.
        /// </summary>
        [DataMember(Name = "width")]
        public virtual int Width { get; set; }
        
        /// <summary>
        /// HtmlAttributions — contains any required attributions. This field will always be present, but may be empty.
        /// </summary>
        [DataMember(Name = "html_attributions")]
        public virtual IEnumerable<string> HtmlAttributions { get; set; }
    }
}