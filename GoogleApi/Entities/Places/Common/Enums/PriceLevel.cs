using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    /// <summary>
    /// Specifies the order in which results are listed for place searches.
    /// </summary>
    [DataContract]
    public enum PriceLevel
    {
        /// <summary>
        /// Free 
        /// </summary>
        [EnumMember(Value = "0")]
        FREE = 0,
        /// <summary>
        /// Inexpensive 
        /// </summary>
        [EnumMember(Value = "1")]
        INEXPENSIVE = 1,
        /// <summary>
        /// Moderate 
        /// </summary>
        [EnumMember(Value = "2")]
        MODERATE = 2,
        /// <summary>
        /// Expensive 
        /// </summary>
        [EnumMember(Value = "3")]
        EXPENSIVE = 3,
        /// <summary>
        /// Very Expensive 
        /// </summary>
        [EnumMember(Value = "4")]
        VERY_EXPENSIVE = 4,
    }
}