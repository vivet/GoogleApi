
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    [DataContract]
    public enum PriceLevel
    {
        [EnumMember]
        Free = 0,
        [EnumMember]
        Inexpensive = 1,
        [EnumMember]
        Moderate = 2,
        [EnumMember]
        Expensive = 3,
        [EnumMember]
        VeryExpensive = 4
    }
}
