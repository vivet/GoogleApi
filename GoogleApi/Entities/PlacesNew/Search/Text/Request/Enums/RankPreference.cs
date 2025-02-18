using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Request.Enums;

/// <summary>
/// The type of ranking to use. If this parameter is omitted, results are ranked by popularity.
/// </summary>
public enum RankPreference
{
    /// <summary>
    /// Ranks results by relevance.Sort order determined by normal ranking stack.
    /// </summary>
    [EnumMember(Value = "RELEVANCE")]
    Popularity,

    /// <summary>
    /// Ranks results by distance.
    /// </summary>
    [EnumMember(Value = "DISTANCE")]
    Distance
}