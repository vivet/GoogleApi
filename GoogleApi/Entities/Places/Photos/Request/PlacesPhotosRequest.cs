using System;
using System.Globalization;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Photos.Request
{
    /// <summary>
    /// Places Photos Request.
    /// </summary>
    public class PlacesPhotosRequest : BasePlacesRequest
    {
        /// <summary>
        /// photoreference (required) — A string identifier that uniquely identifies a photo. Photo references are returned from either a Place Search or Place Details request.
        /// </summary>
        public virtual string PhotoReference { get; set; }

        /// <summary>
        /// maxheight — Specifies the maximum desired height, in pixels, of the image returned by the Place Photos service. 
        /// If the image is smaller than the values specified, the original image will be returned. If the image is larger in either dimension, 
        /// it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio. 
        /// Both the maxheight properties accept an integer between 1 and 1600.
        /// </summary>
        public virtual int? MaxHeight { get; set; }
        
        /// <summary>
        /// maxwidth — Specifies the maximum desired width, in pixels, of the image returned by the Place Photos service.
        ///  If the image is smaller than the values specified, the original image will be returned. If the image is larger in either dimension, 
        /// it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio. 
        /// Both the maxwidth properties accept an integer between 1 and 1600.
        /// </summary>
        public virtual int? MaxWidth { get; set; }

        protected internal override string BaseUrl
        {
            get
            {
                return base.BaseUrl + "photo/";
            }
        }

        protected override QueryStringParametersList GetQueryStringParameters()
        {
            var _parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.PhotoReference))
                throw new ArgumentException("Must specify a PhotoReference");
      
            if (this.MaxHeight == null && this.MaxWidth == null)
                throw new ArgumentException("Must specify a either MaxHeight or MaxWidth.");

            if (this.MaxHeight.HasValue && (this.MaxHeight > 1600 || this.MaxHeight < 1))
                throw new ArgumentException("MaxHeight must be greater than or equal to 1 and less than or equal to 1.600.");

            if (this.MaxWidth.HasValue && (this.MaxWidth > 1600 || this.MaxWidth < 1))
                throw new ArgumentException("MaxWidth must be greater than or equal to 1 and less than or equal to 1.600.");

            _parameters.Add("photoreference", this.PhotoReference);

            if (this.MaxHeight != null)
                _parameters.Add("maxheight", this.MaxHeight.Value.ToString(CultureInfo.InvariantCulture));

            if (this.MaxWidth != null)
                _parameters.Add("maxwidth", this.MaxWidth.Value.ToString(CultureInfo.InvariantCulture));

            return _parameters;
        }
    }
}