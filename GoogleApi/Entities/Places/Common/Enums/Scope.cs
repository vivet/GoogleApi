using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    /// <summary>
    /// Scope.
    /// </summary>
    [DataContract]
    public enum Scope
    {
        /// <summary>
        /// The place ID is recognised by your application only. This is because your application added the place, and the place has not yet passed the moderation process.
        /// </summary>
        [EnumMember(Value = "APP")]
        APP,
        /// <summary>
        /// The place ID is available to other applications and on Google Maps
        /// </summary>
        [EnumMember(Value = "GOOGLE")]
        GOOGLE,
    }
}