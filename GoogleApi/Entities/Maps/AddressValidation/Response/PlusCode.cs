namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Plus Code.
/// Plus code (http://plus.codes) is a location reference with two formats: global code defining a 14mx14m (1/8000th of a degree) or smaller rectangle,
/// and compound code, replacing the prefix with a reference location.
/// </summary>
public class PlusCode
{
    /// <summary>
    /// Global Code.
    /// Place's global (full) code, such as "9FWM33GV+HQ", representing an 1/8000 by 1/8000 degree area (~14 by 14 meters).
    /// </summary>
    public virtual string GlobalCode { get; set; }

    /// <summary>
    /// Global Code.
    /// Place's compound code, such as "33GV+HQ, Ramberg, Norway", containing the suffix of the global code and replacing the prefix
    /// with a formatted name of a reference entity.
    /// </summary>
    public virtual string LocalCode { get; set; }
}