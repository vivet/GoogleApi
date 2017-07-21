using System;
using System.Collections.Generic;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Geolocation.Request.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Maps.Geolocation.Request
{
    /// <summary>
    /// Geolocation Request.
    /// </summary>
    public class GeolocationRequest : BaseMapsRequest, IRequestJson
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/geolocation/v1/geolocate";

        /// <summary>
        /// The carrier name.
        /// </summary>
        [JsonProperty("carrier")]
        public virtual string Carrier { get; set; }

        /// <summary>
        /// The mobile country code (MCC) for the device's home network.
        /// </summary>
        [JsonProperty("homeMobileCountryCode")]
        public virtual string HomeMobileCountryCode { get; set; }

        /// <summary>
        /// The mobile network code (MNC) for the device's home network.
        /// </summary>
        [JsonProperty("homeMobileNetworkCode")]
        public virtual string HomeMobileNetworkCode { get; set; }

        /// <summary>
        /// The mobile radio type. 
        /// Supported values are lte, gsm, cdma, and wcdma. While this field is optional, it should be included if a value is available, 
        /// for more accurate results.
        /// </summary>
        [JsonProperty("radioType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual RadioType? RadioType { get; set; }

        /// <summary>
        /// Specifies whether to fall back to IP geolocation if wifi and cell tower signals are not available. 
        /// Note that the IP address in the request header may not be the IP of the device. 
        /// Defaults to true. 
        /// Set considerIp to false to disable fallback.
        /// </summary>
        [JsonProperty("considerIp")]
        public virtual bool ConsiderIp { get; set; } = true;

        /// <summary>
        /// An array of cell tower objects. See <see cref="CellTower"/>.
        /// </summary>
        [JsonProperty("cellTowers")]
        public virtual IEnumerable<CellTower> CellTowers { get; set; }

        /// <summary>
        /// An array of WiFi access point objects. See  <see cref="WifiAccessPoint"/>.
        /// </summary>
        [JsonProperty("wifiAccessPoints")]
        public virtual IEnumerable<WifiAccessPoint> WifiAccessPoints { get; set; }

        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="QueryStringParameters"/> collection.</returns>
        public override QueryStringParameters GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Key is required");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}