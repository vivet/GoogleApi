using System.Collections.Generic;
using GoogleApi.Entities.PlacesNew.Search.Text.Request.Enums;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Request;

/// <summary>
/// Specifies parameters for identifying available electric vehicle (EV) charging connectors and charging rates
/// </summary>
public class EvOptions
{
    /// <summary>
    /// Filters places by minimum EV charging rate in kilowatts (kW).
    /// Any places with charging a rate less than the minimum charging rate are filtered out.
    /// For example, to find EV chargers with charging rates that are at least 10 kW, you can set this parameter to "10."
    /// </summary>
    public virtual int MinimumChargingRateKw { get; set; }

    /// <summary>
    /// Filters by the type of EV charging connector available at a place.
    /// A place that does not support any of the connector types will be filtered out.
    /// Supported EV charging connector types include combined (AC and DC) chargers, Tesla chargers, GB/T-compliant chargers (for EV fast charging in China),
    /// and wall outlet chargers. For more information, see the reference documentation.
    /// </summary>
    public virtual IEnumerable<EvConnectorType> ConnectorTypes { get; set; } = new List<EvConnectorType>();
}