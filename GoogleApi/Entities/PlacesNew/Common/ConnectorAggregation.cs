using System;
using GoogleApi.Entities.PlacesNew.Common.Enums;
using GoogleApi.Entities.PlacesNew.Search.Text.Request.Enums;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// EV charging information grouped by [type, maxChargeRateKw].
/// Shows EV charge aggregation of connectors that have the same type and max charge rate in kw.
/// </summary>
public class ConnectorAggregation
{
    /// <summary>
    /// The connector type of this aggregation.
    /// </summary>
    public virtual EvConnectorType Type { get; set; }

    /// <summary>
    /// The static max charging rate in kw of each connector in the aggregation.
    /// </summary>
    public virtual double MaxChargeRateKw { get; set; }

    /// <summary>
    /// Number of connectors in this aggregation
    /// </summary>
    public virtual int Count { get; set; }

    /// <summary>
    /// The timestamp when the connector availability information in this aggregation was last updated.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    public virtual DateTime AvailabilityLastUpdateTime { get; set; }

    /// <summary>
    /// Number of connectors in this aggregation that are currently available.
    /// </summary>
    public virtual int AvailableCount { get; set; }

    /// <summary>
    /// Number of connectors in this aggregation that are currently out of service.
    /// </summary>
    public virtual int OutOfServiceCount { get; set; }
}