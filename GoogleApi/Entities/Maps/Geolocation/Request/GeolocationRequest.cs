using System.Collections.Generic;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Geolocation.Request.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Geolocation.Request
{
    /// <summary>
    /// Geolocation Request.
    /// </summary>
    public class GeolocationRequest : BaseMapsRequest
	{
        private const string BASE_URL = "www.googleapis.com/geolocation/v1/geolocate";

        /// <summary>
        /// The carrier name.
        /// </summary>
        public virtual string Carrier { get; set; }
        /// <summary>
        /// The mobile country code (MCC) for the device's home network.
		/// </summary>
        public virtual string HomeMobileCountryCode { get; set; } 
		/// <summary>
        /// The mobile network code (MNC) for the device's home network.
		/// </summary>
        public virtual string HomeMobileNetworkCode { get; set; }
        /// <summary>
        /// The mobile radio type. Supported values are lte, gsm, cdma, and wcdma. While this field is optional, it should be included if a value is available, for more accurate results.
        /// </summary>
        public virtual RadioType? RadioType { get; set; }
        /// <summary>
        /// Specifies whether to fall back to IP geolocation if wifi and cell tower signals are not available. 
        /// Note that the IP address in the request header may not be the IP of the device. Defaults to true. Set considerIp to false to disable fall back.
        /// </summary>
        public virtual bool ConsiderIp { get; set; }
        /// <summary>
        /// An array of cell tower objects. See <see cref="CellTower"/>.
        /// </summary>
        public virtual IEnumerable<CellTower> CellTowers { get; set; }
        /// <summary>
        /// An array of WiFi access point objects. See  <see cref="WifiAccessPoint"/>.
        /// </summary>
        public virtual IEnumerable<WifiAccessPoint> WifiAccessPoints { get; set; }
       	
        protected internal override string BaseUrl
        {
            get
            {
                return GeolocationRequest.BASE_URL;
            }
        }
       
        protected override QueryStringParametersList GetQueryStringParameters()
		{
			var _parameters = base.GetQueryStringParameters();

            if (this.Carrier != null)
                _parameters.Add("carrier", this.Carrier);

            if (this.HomeMobileCountryCode != null)
                _parameters.Add("homeMobileCountryCode", this.HomeMobileCountryCode);

            if (this.HomeMobileNetworkCode != null)
                _parameters.Add("homeMobileNetworkCode", this.HomeMobileNetworkCode);

            if (this.RadioType != null)
                _parameters.Add("radioType", this.RadioType.ToString().ToLower());

            _parameters.Add("considerIp", Sensor.ToString().ToLower());

            // TODO: Add CellTowers and WifiAccessPoints

			return _parameters;
		}
	}
}
