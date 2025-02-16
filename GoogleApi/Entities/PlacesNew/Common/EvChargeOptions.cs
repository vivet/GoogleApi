using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Information about the EV Charge Station hosted in Place.
/// Terminology follows https://afdc.energy.gov/fuels/electricity_infrastructure.html One port could charge one car at a time.
/// One port has one or more connectors. One station has one or more ports.
/// </summary>
public class EvChargeOptions
{
    /// <summary>
    /// Number of connectors at this station. However, because some ports can have multiple connectors
    /// but only be able to charge one car at a time (e.g.) the number of connectors may be greater than the total number of cars which can charge simultaneously.
    /// </summary>
    public virtual int ConnectorCount { get; set; }

    /// <summary>
    /// A list of EV charging connector aggregations that contain connectors of the same type and same charge rate.
    /// </summary>
    public virtual IEnumerable<ConnectorAggregation> ConnectorAggregation { get; set; }
}