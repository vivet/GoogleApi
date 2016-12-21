using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geolocation.Request.Enums
{
    [DataContract]
    public enum RadioType
    {
        LTE,
        GSM,
        CDMA,
        WCDMA
    }
}
