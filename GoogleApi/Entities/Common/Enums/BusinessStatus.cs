namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Business Status.
/// </summary>
public enum BusinessStatus
{
    /// <summary>
    /// Operational.
    /// </summary>
    Operational = 0,

    /// <summary>
    /// Closed Temporarily.
    /// </summary>
    Closed_Temporarily = 1,

    /// <summary>
    /// Closed Permanently
    /// </summary>
    Closed_Permanently = 2,

    //https://github.com/vivet/GoogleApi/issues/305
    /// <summary>
    /// Future Opening.
    /// </summary>
    Future_Opening = 3
}