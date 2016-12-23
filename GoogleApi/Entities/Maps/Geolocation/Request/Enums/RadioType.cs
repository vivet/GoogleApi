using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geolocation.Request.Enums
{
    /// <summary>
    /// RadioType
    /// </summary>
    [DataContract]
    public enum RadioType
    {
        /// <summary>
        /// Radio type lete
        /// </summary>
        [EnumMember(Value = "lte")]
        LTE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "gsm")]
        GSM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "cdma")]
        CDMA,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "wcdma")]
        WCDMA
    }
}
