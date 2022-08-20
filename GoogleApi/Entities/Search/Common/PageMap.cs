using System.Collections.Generic;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// PageMap information.
/// </summary>
public class PageMap
{
    /// <summary>
    /// PageMap information, keyed by the name of this PageMap.
    /// </summary>
    public virtual IDictionary<string, IDictionary<string, string>> List { get; set; }
}