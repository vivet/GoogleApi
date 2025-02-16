using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// The most recent information about fuel options in a gas station. This information is updated regularly.
/// </summary>
public class FuelOptions
{
    /// <summary>
    /// The last known fuel price for each type of fuel this station has. There is one entry per fuel type this station has. Order is not important.
    /// </summary>
    public virtual IEnumerable<FuelPrice> FuelPrices { get; set; }
}