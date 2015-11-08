using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
    /// <summary>
    /// viewport contains the recommended viewport for displaying the returned result, specified as two latitude,longitude values defining the southwest and northeast corner of the viewport bounding box. 
    /// Generally the viewport is used to frame a result when displaying it to a user.
    /// </summary>
	[DataContract]
	public class ViewPort
	{
        /// <summary>
        /// Southwest 
        /// </summary>
		[DataMember(Name = "southwest")]
        public virtual Location SouthWest { get; set; }

        /// <summary>
        /// Northeast
        /// </summary>
		[DataMember(Name = "northeast")]
        public virtual Location NorthEast { get; set; }
	}
}
