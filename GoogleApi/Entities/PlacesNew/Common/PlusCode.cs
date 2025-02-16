namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Plus Code.
/// </summary>
public class PlusCode 
{
    /// <summary>
    /// Place's global (full) code, such as "9FWM33GV+HQ",
    /// representing an 1/8000 by 1/8000 degree area (~14 by 14 meters).
    /// </summary>
    public string GlobalCode { get; set; }

    /// <summary>
    /// Place's compound code, such as "33GV+HQ, Ramberg, Norway",
    /// containing the suffix of the global code and replacing the prefix with a formatted name of a reference entity.
    /// </summary>
    public string CompoundCode { get; set; }
}