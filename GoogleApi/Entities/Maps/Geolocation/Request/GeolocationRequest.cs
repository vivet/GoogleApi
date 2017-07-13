using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Geolocation.Request.Enums;

namespace GoogleApi.Entities.Maps.Geolocation.Request
{
    /// <summary>
    /// Geolocation Request.
    /// </summary>
    [DataContract]
    public class GeolocationRequest : BaseMapsRequest, IRequestJson
    {
        /// <summary>
        /// Base Url.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/geolocation/v1/geolocate";

        /// <summary>
        /// The carrier name.
        /// </summary>
        [DataMember(Name = "carrier")]
        public virtual string Carrier { get; set; }

        /// <summary>
        /// The mobile country code (MCC) for the device's home network.
        /// </summary>
        [DataMember(Name = "homeMobileCountryCode")]
        public virtual string HomeMobileCountryCode { get; set; }

        /// <summary>
        /// The mobile network code (MNC) for the device's home network.
        /// </summary>
        [DataMember(Name = "homeMobileNetworkCode")]
        public virtual string HomeMobileNetworkCode { get; set; }

        /// <summary>
        /// The mobile radio type. Supported values are lte, gsm, cdma, and wcdma. While this field is optional, it should be included if a value is available, for more accurate results.
        /// </summary>
        [DataMember(Name = "radioType")]
        public virtual RadioType? RadioType { get; set; }

        /// <summary>
        /// Specifies whether to fall back to IP geolocation if wifi and cell tower signals are not available. 
        /// Note that the IP address in the request header may not be the IP of the device. Defaults to true. Set considerIp to false to disable fall back.
        /// </summary>
        [DataMember(Name = "considerIp")]
        public virtual bool ConsiderIp { get; set; }

        /// <summary>
        /// An array of cell tower objects. See <see cref="CellTower"/>.
        /// </summary>
        [DataMember(Name = "cellTowers")]
        public virtual IEnumerable<CellTower> CellTowers { get; set; }

        /// <summary>
        /// An array of WiFi access point objects. See  <see cref="WifiAccessPoint"/>.
        /// </summary>
        [DataMember(Name = "wifiAccessPoints")]
        public virtual IEnumerable<WifiAccessPoint> WifiAccessPoints { get; set; }

        /// <summary>
        /// See <see cref="BaseRequest.QueryStringParameters"/>.
        /// </summary>
        /// <returns>A <see cref="QueryStringParameters"/> colletion.</returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Key))
                    throw new ArgumentException("Key is required");

                var parameters = base.QueryStringParameters;

                // TODO: Valudate JSon Body.

                return parameters;
            }
        }
    }
}