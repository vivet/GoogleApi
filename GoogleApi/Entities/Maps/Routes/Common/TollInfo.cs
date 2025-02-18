using System.Collections.Generic;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Toll Info.
/// Encapsulates toll information on a Route or on a RouteLeg.
/// </summary>
public class TollInfo
{
    /// <summary>
    /// Estimated Price.
    /// The monetary amount of tolls for the corresponding Route or RouteLeg.
    /// This list contains a money amount for each currency that is expected to be charged by the toll stations.
    /// Typically this list will contain only one item for routes with tolls in one currency.
    /// For international trips, this list may contain multiple items to reflect tolls in different currencies.
    /// </summary>
    public virtual IEnumerable<Money> EstimatedPrice { get; set; }
}