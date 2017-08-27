using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Enums
{
    /// <summary>
    /// Site Search Filter.
    /// </summary>
    public enum SiteSearchFilter
    {
        /// <summary>
        /// Include.
        /// </summary>
        [EnumMember(Value = "i")]
        Include,

        /// <summary>
        /// Exclude.
        /// </summary>
        [EnumMember(Value = "e")]
        Exclude
    }
}