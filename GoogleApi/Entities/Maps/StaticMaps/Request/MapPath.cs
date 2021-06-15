using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Entities.Maps.StaticMaps.Request
{
	/// <summary>
	/// Map Path.
	/// Defines a single path of two or more connected points to overlay on the image at specified locations. 
	/// </summary>
	public class MapPath
    {
        /// <summary>
        /// Weight (optional) specifies the thickness of the path in pixels. 
        /// If no weight parameter is set, the path will appear in its default thickness (5 pixels).
        /// </summary>
        public virtual int Weight { get; set; } = 5;

        /// <summary>
        /// Geodesic: (optional) indicates that the requested path should be interpreted as a geodesic line that follows the curvature of the earth.
        /// When false, the path is rendered as a straight line in screen space. 
        /// Defaults to false.
        /// </summary>
        public virtual bool Geodesic { get; set; } = false;

        /// <summary>
        /// Color (optional) specifies a color either as a 24-bit (example: color=0xFFFFCC) or 32-bit hexadecimal value (example: color=0xFFFFCCFF), 
        /// or from the set {black, brown, green, purple, yellow, blue, gray, orange, red, white}.  
        /// When a 32-bit hex value is specified, the last two characters specify the 8-bit alpha transparency value.
        /// This value varies between 00 (completely transparent) and FF (completely opaque). 
        /// Note that transparencies are supported in paths, though they are not supported for markers.
        /// </summary>
        public virtual string Color { get; set; }

        /// <summary>
        /// Fillcolor (optional) indicates both that the path marks off a polygonal area and specifies the fill color to use as an overlay within that area. 
        /// The set of locations following need not be a "closed" loop; the Google Static Maps API server will automatically join the first and last points. 
        /// Note, however, that any stroke on the exterior of the filled area will not be closed unless you specifically provide the same beginning and end location.
        /// </summary>
        public virtual string FillColor { get; set; }

        /// <summary>
        /// Gets or sets the collection of points for this path
        /// </summary>
        public virtual IEnumerable<Location> Points { get; set; } = new List<Location>();

        /// <summary>
        /// Returns a string representation of a <see cref="MapPath"/>.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            var weight = $"weight:{this.Weight}";
            var geodesic = $"geodesic:{this.Geodesic.ToString().ToLower()}";
            var color = this.Color != null ? $"color:{this.Color}" : null;
            var fillColor = this.FillColor != null ? $"fillcolor:{this.FillColor}" : null;

            var styles = new[]
            {
                weight,
                geodesic,
                color,
                fillColor
            }.Where(x => x != null);

            var points = string.Join("|", this.Points.Select(x => x.ToString()));

            return $"{string.Join("|", styles)}|{points}";
        }
    }
}