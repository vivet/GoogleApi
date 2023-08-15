namespace GoogleApi.Entities.Places.Common;

/// <summary>
/// Contains a summary of the place.
/// A summary is comprised of a textual overview, and also includes the language code for these if applicable.
/// Summary text must be presented as-is and can not be modified or altered.
/// </summary>
public class EditorialSummary
{
    /// <summary>
    /// The language of the previous fields.
    /// May not always be present.
    /// </summary>
    public virtual string Language { get; set; }

    /// <summary>
    /// Overview.
    /// Summary text of the place.
    /// </summary>
    public virtual string Overview { get; set; }
}