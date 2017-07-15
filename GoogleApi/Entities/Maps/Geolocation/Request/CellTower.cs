using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geolocation.Request
{
    /// <summary>
    /// The request body's cellTowers array contains zero or more cell tower objects.
    /// </summary>
    public class CellTower
    {
        /// <summary>
        /// Required. Unique identifier of the cell. On GSM, this is the Cell ID (CID); CDMA networks use the Base Station ID (BID). 
        /// WCDMA networks use the UTRAN/GERAN Cell Identity (UC-Id), which is a 32-bit value concatenating the Radio Network Controller (RNC) and Cell ID. 
        /// Specifying only the 16-bit Cell ID value in WCDMA networks may return inaccurate results.
        /// </summary>
        [JsonProperty("cellId")]
        public virtual string CellId { get; set; }

        /// <summary>
        /// Required. The Location Area Code (LAC) for GSM and WCDMAnetworks. 
        /// The Network ID (NID) for CDMA networks.
        /// </summary>
        [JsonProperty("locationAreaCode")]
        public virtual string LocationAreaCode { get; set; }

        /// <summary>
        /// Required. The cell tower's Mobile Country Code (MCC).
        /// </summary>
        [JsonProperty("mobileCountryCode")]
        public virtual string MobileCountryCode { get; set; }

        /// <summary>
        /// Required. The cell tower's Mobile Network Code. 
        /// This is the MNC for GSM and WCDMA; CDMA uses the System ID (SID).
        /// </summary>
        [JsonProperty("mobileNetworkCode")]
        public virtual string MobileNetworkCode { get; set; }

        /// <summary>
        /// The number of milliseconds since this cell was primary. If age is 0, the cellId represents a current measurement.
        /// </summary>
        [JsonProperty("age")]
        public virtual int? Age { get; set; }

        /// <summary>
        /// Radio signal strength measured in dBm.
        /// </summary>
        [JsonProperty("signalStrength")]
        public virtual int? SignalStrength { get; set; }

        /// <summary>
        /// The timing advance value.
        /// </summary>
        [JsonProperty("timingAdvance")]
        public virtual int? TimingAdvance { get; set; }
    }
}