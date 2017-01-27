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
        [EnumMember(Value = "lte")] Lte,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "gsm")] Gsm,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "cdma")] Cdma,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "wcdma")] Wcdma
    }
}