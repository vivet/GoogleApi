namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Encapsulates a corrected query.
/// </summary>
public class Spelling
{
    /// <summary>
    /// The corrected query.
    /// </summary>
    public virtual string CorrectedQuery { get; set; }

    /// <summary>
    /// The corrected query, formatted in HTML.
    /// </summary>
    public virtual string HtmlCorrectedQuery { get; set; }
}