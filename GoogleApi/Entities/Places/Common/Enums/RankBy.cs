using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    [DataContract]
    public enum RankBy
    {
        /// <summary>
        /// This option sorts results based on their importance. Ranking will favor prominent places within the specified area. Prominence can be affected by a place's ranking in Google's index, global popularity, and other factors.
        /// </summary>
        [EnumMember(Value = "prominence ")]
        Prominence,

        /// <summary>
        ///  This option sorts results in ascending order by their distance from the specified location. When distance is specified, one or more of keyword, name, or types is required.
        /// </summary>
        [EnumMember(Value = "distance ")]
        Distance
    }
}
