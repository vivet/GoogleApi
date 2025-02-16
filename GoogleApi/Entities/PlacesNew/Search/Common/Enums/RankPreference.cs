using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Search.Common.Enums;

/// <summary>
/// The type of ranking to use. If this parameter is omitted, results are ranked by popularity.
/// </summary>
public enum RankPreference
{
    /// <summary>
    /// Sorts results based on their popularity (default).
    /// </summary>
    [EnumMember(Value = "POPULARITY")]
    Popularity,

    /// <summary>
    /// Sorts results in ascending order by their distance from the specified location.
    /// </summary>
    [EnumMember(Value = "DISTANCE")]
    Distance
}