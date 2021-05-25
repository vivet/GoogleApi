using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Common;
using Location = GoogleApi.Entities.Common.Location;

namespace GoogleApi.Entities.Maps.StreetView.Request
{
	/// <summary>
	/// Street View Request.
	/// </summary>
	public class StreetViewRequest : BaseMapsChannelRequest
	{
		/// <inheritdoc />
		protected internal override string BaseUrl { get; } = "maps.googleapis.com/maps/api/streetview";

		/// <summary>
		/// location can be either a text string (such as Chagrin Falls, OH) or a lat/lng value (40.457375,-80.009353). 
		/// The Google Street View Image API will snap to the panorama photographed closest to this location. 
		/// When an address text string is provided, the API may use a different camera location to better display the specified location. When a lat/lng is provided, 
		/// the API searches a 50 meter radius for a photograph closest to this location. 
		/// Because Street View imagery is periodically refreshed, and photographs may be taken from slightly different positions each time, 
		/// it's possible that your location may snap to a different panorama when imagery is updated.
		/// </summary>
		public virtual Location Location { get; set; }

		/// <summary>
		/// Pano is a specific panorama ID. These are generally stable
		/// Either Address, Location or Pano is required.
		/// </summary>
		public virtual string PanoramaId { get; set; }

		/// <summary>
		/// Size specifies the output size of the image in pixels. Required.
		/// Size is specified as {width}x{height} - for example, size=600x400 returns an image 600 pixels wide, and 400 high.
		/// </summary>
		public virtual MapSize Size { get; set; } = new MapSize(600, 400);

		/// <summary>
		/// Pitch (default is 0) specifies the up or down angle of the camera relative to the Street View vehicle. 
		/// This is often, but not always, flat horizontal. Positive values angle the camera up (with 90 degrees indicating straight up); 
		/// negative values angle the camera down (with -90 indicating straight down).
		/// </summary>
		public virtual short Pitch { get; set; } = 0;

		/// <summary>
		/// Heading indicates the compass heading of the camera. 
		/// Accepted values are from 0 to 360 (both values indicating North, with 90 indicating East, and 180 South). 
		/// If no heading is specified, a value will be calculated that directs the camera towards the specified location, 
		/// from the point at which the closest photograph was taken.
		/// </summary>
		public virtual short? Heading { get; set; }

		/// <summary>
		/// Fov (default is 90) determines the horizontal field of view of the image. 
		/// The field of view is expressed in degrees, with a maximum allowed value of 120. 
		/// When dealing with a fixed-size viewport, as with a Street View image of a set size, 
		/// field of view in essence represents zoom, with smaller numbers indicating a higher level of zoom.
		/// </summary>
		public virtual short FieldOfView { get; set; } = 90;
	
		/// <inheritdoc />
		public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
		{
			var parameters = base.GetQueryStringParameters();

		    if (string.IsNullOrEmpty(this.Key))
		        throw new ArgumentException("Key is required");

            if (this.PanoramaId != null)
		    {
		        parameters.Add("pano", this.PanoramaId);
		    }
			else if (this.Location != null)
		    {
		        parameters.Add("location", this.Location.ToString());
		    }
			else
				throw new ArgumentException("Location or PanoramaId is required");

			parameters.Add("size", $"{this.Size.Width}x{this.Size.Height}");

		    if (this.Pitch >= -90 && this.Pitch <= 90)
		    {
		        parameters.Add("pitch", this.Pitch.ToString());
		    }
			else
				throw new ArgumentException("Pitch must be greater than -90 and less than 90");

            if (this.Heading.HasValue)
            {
                if (this.Heading >= 0 && this.Heading <= 360)
				    parameters.Add("heading", this.Heading.ToString());
			    else
				    throw new ArgumentException("Heading must be greater than 0 and less than 360");
            }

		    if (this.FieldOfView >= 0 && this.FieldOfView <= 120)
		    {
		        parameters.Add("fov", this.FieldOfView.ToString());
		    }
			else
				throw new ArgumentException("Field of view must be greater than 0 and less than 120");

			return parameters;
		}
	}
}
